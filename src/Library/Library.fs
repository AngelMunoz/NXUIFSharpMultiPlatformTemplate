namespace Library

open FSharp.Control.Reactive
open FSharp.Control.Reactive.Builders

open Avalonia
open Avalonia.Data
open Avalonia.Controls
open Avalonia.Controls.ApplicationLifetimes
open Avalonia.Themes.Fluent

open NXUI.FSharp.Extensions

module View =
  let Content () : Control =
    let counter = Subject.behavior 0

    let counterText = observe {
      let! contents = counter
      $"You clicked {contents} times"
    }

    let incrementOnClick _ _ = counter.OnNext(counter.Value + 1)

    StackPanel()
      .children(
        Button()
          .content("Click me!!")
          .OnClickHandler(incrementOnClick),
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
