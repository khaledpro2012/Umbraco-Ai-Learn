import { spawn } from "node:child_process";
import process from "node:process";
import dotenv from "dotenv";

dotenv.config();

const required = [
  "UMBRACO_CLIENT_ID",
  "UMBRACO_CLIENT_SECRET",
  "UMBRACO_BASE_URL",
  "UMBRACO_INCLUDE_TOOL_COLLECTIONS"
];

const missing = required.filter((key) => !process.env[key]);
if (missing.length > 0) {
  console.error("Missing required environment values:", missing.join(", "));
  console.error("Create a .env file from .env.mcp.example and fill in values.");
  process.exit(1);
}

const command = process.platform === "win32" ? "npx.cmd" : "npx";
const child = spawn(command, ["@umbraco-cms/mcp-dev@latest"], {
  stdio: "inherit",
  env: {
    ...process.env,
    NODE_TLS_REJECT_UNAUTHORIZED: process.env.NODE_TLS_REJECT_UNAUTHORIZED || "0"
  }
});

child.on("exit", (code, signal) => {
  if (signal) {
    console.error(`Umbraco MCP exited due to signal: ${signal}`);
    process.exit(1);
  }
  process.exit(code ?? 0);
});
