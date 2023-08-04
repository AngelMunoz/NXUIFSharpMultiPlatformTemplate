namespace Library

open System.Reactive.Subjects

open Avalonia
open Avalonia.Data
open Avalonia.Controls

open NXUI.FSharp.Extensions
open Avalonia.Controls.ApplicationLifetimes
open Avalonia.Themes.Fluent

module View =
  let Content () : Control =
    let counter = new BehaviorSubject<int> 0

    let counterText =
      counter |> Observable.map(fun count -> $"You clicked %i{count} times")

    let incrementOnClick _ observable =
      observable |> Observable.add(fun _ -> counter.OnNext(counter.Value + 1))

    StackPanel()
      .children(
        Button()
          .content("Click me!!")
          .OnClick(incrementOnClick),
        TextBlock()
          .text(counterText, BindingMode.OneWay)
      )


type App() =
  inherit Application()

  override this.Initialize() =
    this.Styles.Add(FluentTheme())
    this.RequestedThemeVariant <- Styling.ThemeVariant.Dark

  override this.OnFrameworkInitializationCompleted() =
    match this.ApplicationLifetime with
    | :? IClassicDesktopStyleApplicationLifetime as desktopLifetime ->
      let window =
        Window()
          .title("NXUI and F#")
          .width(300)
          .height(300)
          .content(View.Content())

      desktopLifetime.MainWindow <- window
    | :? ISingleViewApplicationLifetime as singleViewLifetime ->
      singleViewLifetime.MainView <- View.Content()
    | _ -> ()

    base.OnFrameworkInitializationCompleted()
