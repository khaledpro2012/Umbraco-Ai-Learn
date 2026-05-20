# Umbraco MCP + Skills Starter

This repository is prepared for Umbraco AI workflows with:
- Umbraco Developer MCP server configuration for VS Code
- Reusable skill folders for common Umbraco tasks

## What was added

- `.vscode/mcp.json`: MCP server entry using `npx @umbraco-cms/mcp-dev@latest`
- `.env.mcp.example`: environment variable template for Umbraco credentials
- `.github/skills/*`: starter agent skills in `SKILL.md` format

## Prerequisites

1. Node.js 22+
2. A local or isolated Umbraco instance (not production)
3. Umbraco API User credentials:
   - Client ID
   - Client Secret
   - Base URL

## Setup

1. Install dependencies:

```powershell
npm install
```

2. Create your local env file and fill in secrets:

```powershell
Copy-Item .env.mcp.example .env
```

3. The MCP server config in `.vscode/mcp.json` runs `node scripts/run-umbraco-mcp.mjs`.
   - The script loads `.env` and launches `@umbraco-cms/mcp-dev@latest`.

4. Restart your editor/host so MCP reconnects.

## MCP config reference

The server uses:

- Command: `npx`
- Package: `@umbraco-cms/mcp-dev@latest`
- Tool collections: controlled by `UMBRACO_INCLUDE_TOOL_COLLECTIONS`

Example tool collections:
- `document,media`
- `document,media,document-type,data-type`

## Safety

- Use only local, dev, or isolated staging environments.
- Do not connect this MCP setup to production.

## Skills

See `.github/skills/README.md` for details and usage.
