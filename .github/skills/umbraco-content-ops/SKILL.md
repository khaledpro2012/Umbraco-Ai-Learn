---
name: umbraco-content-ops
description: Run safe, repeatable bulk content and media operations in Umbraco using MCP tools.
---

# Umbraco Content Operations Skill

## When to use

Use this skill when the task involves:
- Bulk content updates
- Content republish operations
- Media cleanup, rename, move, or metadata normalization
- Auditing content structures before edits

## Core workflow

1. Confirm target environment is non-production.
2. Inspect target items first (dry-run mindset).
3. Plan scoped operations (small batches).
4. Execute with explicit filters and clear stop conditions.
5. Re-verify affected items after actions.
6. Summarize what changed and what was skipped.

## Guardrails

- Never run against production.
- Prefer smallest needed tool collection.
- Ask for confirmation before destructive actions (delete/unpublish/move at scale).
- Keep an operation log (ids, paths, before/after key fields).

## Prompt template

Use this structure when operating:

- Goal: <specific outcome>
- Scope: <root node/folder/type/language>
- Constraints: <no deletes / no schema changes / max N updates>
- Validation: <how success is verified>

## Example asks

- "Normalize all media names in folder X to title case and keep originals in report."
- "Update property Y on all articles under node Z, then republish changed nodes only."
- "Audit unpublished nodes in section A and return candidate remediation list."
