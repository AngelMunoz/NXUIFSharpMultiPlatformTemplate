# NXUI + F# Goes CrossPlatform

This is a simple template to get started with [Avalonia](https://avaloniaui.net/) and [F#](https://fsharp.org/) through [NXUI](https://github.com/wieslawsoltes/NXUI).

To get started with the code type the following commands in your terminal:

```pwsh
dotnet workload install android ios wasm-tools # to be able to run Android,iOS, and Browser targets
dotnet tool restore
dotnet build
```

> ***NOTE***: In some cases you might need to run the command with elevated priviledges
>  you can find more information here https://learn.microsoft.com/en-us/dotnet/core/tools/dotnet-workload-install#when-to-run-elevated


After that you can run the desired platform:

```pwsh
dotnet run --project src/<Project.Directory>
```

You should briefly see your application window showing on your selected platform.

# Alternatives

Although NXUI is a great way to get started with Avalonia and F#, there are other options available:

- Plain [Avalonia](https://avaloniaui.net/)
- [Avalonia.FuncUI](https://github.com/fsprojects/Avalonia.FuncUI)
- [Fabulous.Avalonia](https://github.com/fabulous-dev/Fabulous.Avalonia)
- [Elmish.Avalonia](https://github.com/JordanMarr/Elmish.Avalonia)

All of them offer similar or different approaches to building UIs with F#.
