# Copilot Instructions

## Shared Instructions

Shared Copilot instructions, skills and prompts are maintained centrally in the
[account-level `.github` repository](https://github.com/f2calv/.github). They are deliberately not
copied here.

To load them, clone that repository and either add it to the VS Code workspace or link its
instruction, skill and prompt folders into `~/.copilot/`. If those files are unavailable, stop
rather than guessing the conventions.

Everything below is specific to this repository.

## Repository Purpose

This repository is a .NET RabbitMQ producer/consumer playground. The Compose stack starts the
broker and builds the two example applications.

- Keep message contracts and broker integration shared through `SharedLibrary`.
- Make producer and consumer contract changes together.
- Use synthetic payloads and local development credentials only; never commit broker credentials.
