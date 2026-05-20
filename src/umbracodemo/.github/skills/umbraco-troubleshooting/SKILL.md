---
name: umbraco-troubleshooting
description: Diagnose Umbraco and Management API issues with evidence-first, low-risk remediation.
---

# Umbraco Troubleshooting Skill

## When to use

Use this skill for:
- MCP tool failures
- Management API authentication/authorization issues
- Unexpected validation errors in content or schema operations
- Version mismatch and connectivity diagnostics

## Diagnostic workflow

1. Collect error evidence (exact messages, status codes, timestamps).
2. Classify failure type:
   - Auth/AuthZ
   - Validation
   - Connectivity/TLS
   - Version compatibility
   - Data/state conflicts
3. Reproduce with minimal scope.
4. Propose least-risk fix first.
5. Re-run verification checks.
6. Document root cause and prevention.

## Guardrails

- No speculative destructive fixes.
- Keep each remediation step reversible.
- If credentials are involved, rotate/regenerate as needed and avoid leaking values.

## Quick checks

- Node.js version is 22+
- `UMBRACO_BASE_URL` is reachable from host
- `UMBRACO_CLIENT_ID` and `UMBRACO_CLIENT_SECRET` match API user
- Tool collections include required domains for requested operations
- Umbraco major version matches supported MCP package version

## Example asks

- "Investigate why MCP content update calls return 401 and list exact remediation steps."
- "Diagnose version-check errors on startup and provide a compatibility matrix for this project."
- "Analyze repeated validation failures on document creation and suggest safe schema fixes."
