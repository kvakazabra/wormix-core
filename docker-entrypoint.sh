#!/bin/sh
set -e

if [ -f /host-root/wormix-core.json ]; then
  CONFIG=/host-root/wormix-core.json
  echo "Using custom config: $CONFIG"
else
  CONFIG=/host-root/configs/docker-example.json
  echo "No wormix-core.json found at project root — using default docker-example config."
fi

exec dotnet wormix-core.dll "$CONFIG"