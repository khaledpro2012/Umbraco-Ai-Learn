---
name: umbraco-schema-workflow
description: Design and evolve Umbraco document/data types with safe migrations and consistency checks.
---

# Umbraco Schema Workflow Skill

## When to use

Use this skill for:
- Designing new document type hierarchies
- Refactoring existing document or data types
- Property editor standardization
- Naming convention cleanup

## Schema-first workflow

1. Capture business intent and editor workflows.
2. Draft the target model (types, compositions, properties, allowed children).
3. Compare current vs target schema.
4. Plan incremental changes to avoid editor disruption.
5. Execute changes in controlled order.
6. Validate content compatibility and backoffice usability.

## Guardrails

- Avoid breaking property aliases unless migration is explicitly approved.
- Prefer additive changes before destructive removals.
- Record compatibility notes for each changed type.
- Keep naming conventions consistent:
  - Type aliases: kebab or camel style (project standard)
  - Property aliases: stable and semantic

## Prompt template

- Current state: <what exists now>
- Target state: <desired schema>
- Constraints: <must keep aliases / no data loss>
- Migration strategy: <additive -> migrate -> cleanup>

## Example asks

- "Create a reusable SEO composition and apply it to article and landing page types."
- "Refactor old event types into a shared base composition without alias changes."
- "Generate a schema review report with naming and editor UX recommendations."
