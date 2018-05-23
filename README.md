# The Touch Issue on Windows 10.0.17134

On Windows 10 (1803), all applications lost touch or stylus if a WPF transparent window covers on them.

If I create a new WPF application with a simple empty window like the code shown below, I find that all applications which are covered by the WPF app lost touch or stylus reaction. This can only be reproduced when Windows 10 is upgraded to 1803 (10.0.17134.0).

```xml
<Window x:Class="TheWPFCoveringWindow.MainWindow"
        xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
        xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
        WindowStyle="None" WindowState="Maximized"
        AllowsTransparency="True" Background="Transparent"
        Topmost="True">
    <Button Content="Test" Width="200" Height="100" />
</Window>
```

I wrote another WPF application to find out what happened. So I add a StylusDown event to the Window like the code shown below:

```csharp
// This code is in another WPF application.
private void OnStylusDown(object sender, StylusDownEventArgs e)
{
    // Set a breakpoint here.
}
```

But the breakpoint never reached until I closed the transparent WPF window which is on top.

I pushed the very simple code to GitHub: [dotnet-campus/TouchIssueOnWindows10.0.17134](https://github.com/dotnet-campus/TouchIssueOnWindows10.0.17134). Cloning it might help a little.

Why does this happen and how to solve it?

## Solution

If you have a Window that set the following properties.

```csharp
            WindowStyle = WindowStyle.None;
            WindowState = WindowState.Maximized;
```

Or

```csharp
            WindowStyle="None" 
            AllowsTransparency="True"
```

You must set `ResizeMode="NoResize"` to avoid some problems as 

 - All applications lost touch or stylus if a WPF transparent window covers on them.

 - Windows appears offset when set it to `Maximized` from `Normal`.

 - Windows appears offset when switch screen.

See [c# - On Windows 10 (1803), all applications lost touch or stylus if a WPF transparent window covers on them](https://stackoverflow.com/questions/50382605/on-windows-10-1803-all-applications-lost-touch-or-stylus-if-a-wpf-transparent )

[On Windows 10 (1803), all applications lost touch or stylus if a WPF transparent window covers on them - Developer Community](https://developercommunity.visualstudio.com/content/problem/255063/on-windows-10-1803-all-applications-lost-touch-or.html )
