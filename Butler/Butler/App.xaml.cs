using System;
using System.Windows;
using MahApps.Metro;

namespace Butler
{
   public partial class App : Application
    {
        
	    protected override void OnStartup(StartupEventArgs e)
	    {
		    // add custom accent and theme resource dictionaries to the ThemeManager
		    // you should replace MahAppsMetroThemesSample with your application name
		    // and correct place where your custom accent lives
		    ThemeManager.AddAccent("ButlerAccent", new Uri("pack://application:,,,/ArcDps Butler;component/ButlerAccent.xaml"));

		    // get the current app style (theme and accent) from the application
		    Tuple<AppTheme, Accent> theme = ThemeManager.DetectAppStyle(Application.Current);

		    // now change app style to the custom accent and current theme
		    ThemeManager.ChangeAppStyle(Application.Current,
			    ThemeManager.GetAccent("ButlerAccent"),
			    theme.Item1);

		    base.OnStartup(e);
	    }
	}
}
