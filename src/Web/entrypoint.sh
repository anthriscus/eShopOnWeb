#!/bin/bash
# just to try out pushing json test data into the container for the seeding.
# push from volume to home where the cs picks it up
# see src/Infrastructure/Data/CatalogContextSeed.cs
# 
for f in "$WORKSPACETEST/"*; do cp "$f" "$HOME"; done

dotnet Web.dll