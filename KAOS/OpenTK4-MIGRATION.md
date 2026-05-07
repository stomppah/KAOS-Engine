# OpenTK 4 Migration Notes

This repository has been moved off the legacy OpenTK 1.x package and onto OpenTK 4 package references at the project level.

## What changed

- `KAOS.csproj` was upgraded from a legacy .NET Framework-style MSBuild project to SDK-style.
- Target framework was modernized to `net8.0-windows` to support current runtime/tooling.
- OpenTK package references were upgraded to:
  - `OpenTK` 4.8.2
  - `OpenTK.GLControl` 4.8.2
- Legacy `packages.config` style dependencies were replaced with `PackageReference`.
- NUnit and AssimpNet dependencies were upgraded to maintained package versions.

## Next migration steps

The runtime code currently uses legacy OpenTK namespaces and APIs (e.g. `OpenTK.Input`, `OpenTK.GameWindow` constructor signatures, and old event args). To fully complete OpenTK 4 migration, update in this order:

1. `KAOSEngine` inheritance and constructors to `OpenTK.Windowing.Desktop.GameWindow` with `GameWindowSettings`/`NativeWindowSettings`.
2. Input manager and keyboard/mouse usage to `OpenTK.Windowing.GraphicsLibraryFramework.Keys` and new input event model.
3. Math types to `OpenTK.Mathematics` where needed.
4. GL compatibility calls (fixed-function matrix stack) to modern shader-uniform matrix flow where required.
5. Any Editor/Game projects that directly reference old OpenTK APIs.

## Scope choice

This commit prioritizes project-system modernization first to make the source tree OpenTK 4-capable for iterative code migration.
