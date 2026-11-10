# Working rules for Claude

## Token-efficient working rules

### Before reading code
- If `graphify-out/graph.json` exists, query it first (`graphify query "<question>"`, `graphify explain "<Name>"`, `graphify path "<A>" "<B>"`) and open only the files it points to. If it is missing or stale and the task spans many files, run `graphify update .` once (code-only, no LLM cost).
- Use Grep/Glob with tight patterns before Read. Read only the needed line range of large files (offset/limit). Don't re-read a file already read or edited in this session.
- Check project docs, notes and existing scripts before exploring from scratch.

### Large outputs
- Compress big command/SQL/log/JSON output with `headroom_compress` (from user-scope `headroom` MCP) before reasoning over it. Use `headroom_retrieve` only when exact detail is needed.
- SQL: select only the needed columns, use TOP/WHERE, never `SELECT *` on big tables.
- Builds and tests: show errors and failures only, not full logs.

### Doing the work (Ponytail)
- Smallest complete change (`ponytail@ponytail` user plugin is enabled). Reuse existing DALs, helpers, `DataAccessManager`/`DataAccessManagerAsync`, and patterns. No new abstractions, options, dependencies or "for later" code.
- Run independent tool calls in parallel. Don't spawn subagents for work that takes a few tool calls.
- Ask only when a decision is really the user's. Otherwise pick the sensible default and say so in one line.
- Don't load a skill or plugin unless the task needs it.
- Never put passwords, keys or connection strings in new files; point to where they live.

### Answers
- Short: what changed (file links), how it was verified, what was not checked or is risky.
- No long explanations, no repeating code already written, no restating tool output.
- Reply in the user's language.

## Project facts
- Stack: ASP.NET Web API 2 + MVC 5 on .NET Framework 4.7.2 (`SalesSolution.sln`), OWIN Bearer Auth + `BasicTokenAuth`, Entity Framework 6.1.3 + `System.Data.SqlClient`.
- Main folders: `SalesSolutionWebAPI/` — `Controllers/` (API endpoints), `Repository/` (`*DAL.cs`), `Interface/` (`i*.cs`), `Models/`, `DataManager/` (`DataAccessManager.cs`, `DataAccessManagerAsync.cs`, `DataBase.cs`, `SqlUserAccess.cs`), `EFModel/`, `Providers/`, `Results/`, `Utilities/`, `App_Start/`, `Areas/HelpPage/`, `Views/`.
- Database: SQL Server (`SalesDisDB_UniWorld_DB`, `CSTL_ClickPharmaDB` defined in `SalesSolutionWebAPI/DataManager/DataBase.cs`; connection target/credentials live in `SalesSolutionWebAPI/DataManager/SqlUserAccess.cs`; EF connection string `SalesRollDB_ZASEntities` lives in `SalesSolutionWebAPI/Web.config`).
- Build: `"C:\Program Files\Microsoft Visual Studio\18\Professional\MSBuild\Current\Bin\MSBuild.exe" SalesSolution.sln /p:Configuration=Debug /clp:ErrorsOnly /m /nologo`
- Test / run: No automated test project in `SalesSolution.sln`; run via IIS Express / Visual Studio.
- DB change scripts go in: `SalesSolutionWebAPI/` (`Database_*.sql`).
- Tooling: Graphify (`graphify-out/` + `.claude/settings.json` PreToolUse hook), Headroom (user-scope MCP `headroom` in `~/.claude.json`), Ponytail (user-scope plugin `ponytail@ponytail`).

## graphify

This project has a knowledge graph at graphify-out/ with god nodes, community structure, and cross-file relationships.

Rules:
- When graphify-out/graph.json exists, run `graphify query "<question>"` before your first grep, search or source-file read for a codebase question, and put this rule in every subagent prompt that explores code. Read raw files only for lines the graph or an earlier read already located. Use `graphify path "<A>" "<B>"` for relationships and `graphify explain "<concept>"` for focused concepts. These return a scoped subgraph, usually much smaller than GRAPH_REPORT.md or raw grep output.
- If graphify-out/wiki/index.md exists, use it for broad navigation instead of raw source browsing.
- Read graphify-out/GRAPH_REPORT.md only for broad architecture review or when query/path/explain do not surface enough context.
- After modifying code, run `graphify update .` to keep the graph current (AST-only, no API cost).
- A committed graphify-out/graph.json is rewritten whole on every build, so a large diff to it in a pull request is expected. Do not flag it as churn or suggest skipping the graph rebuild or its hooks.
