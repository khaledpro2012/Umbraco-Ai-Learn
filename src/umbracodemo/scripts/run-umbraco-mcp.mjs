import { config as loadEnv } from "dotenv";
import { spawn } from "node:child_process";
import { existsSync } from "node:fs";
import path from "node:path";
import { fileURLToPath } from "node:url";

const __filename = fileURLToPath(import.meta.url);
const __dirname = path.dirname(__filename);
const projectRoot = path.resolve(__dirname, "..");
const envPath = path.join(projectRoot, ".env");

if (existsSync(envPath)) {
  loadEnv({ path: envPath });
}

const requiredKeys = [
  "UMBRACO_BASE_URL",
  "UMBRACO_CLIENT_ID",
  "UMBRACO_CLIENT_SECRET"
];

const missingKeys = requiredKeys.filter((key) => !process.env[key]?.trim());

if (missingKeys.length > 0) {
  console.error("Missing required Umbraco MCP environment variables:");
  for (const key of missingKeys) {
    console.error(`- ${key}`);
  }

  console.error(`\nExpected .env file: ${envPath}`);
  console.error("Create it from template: Copy-Item .env.mcp.example .env");
  process.exit(1);
}

const child = spawn(
  "npx",
  ["-y", "@umbraco-cms/mcp-dev@latest"],
  {
    stdio: "inherit",
    shell: process.platform === "win32",
    env: process.env,
    cwd: projectRoot
  }
);

child.on("exit", (code, signal) => {
  if (signal) {
    process.kill(process.pid, signal);
    return;
  }

  process.exit(code ?? 0);
});
