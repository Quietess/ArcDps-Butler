using System;
using Autofac;
using EVTC_Log_Parser;
using Butler.Logic;
using Butler.Logic.Interfaces;
using Butler.Logic.LogDetectionStrategies;
using Butler.ViewModels;
using ReactiveUI;

namespace Butler
{
	public static class BootStrapper
	{
		[STAThread]
		public static void Main(string[] args)
		{
			var containerBuilder = new ContainerBuilder();
			containerBuilder.RegisterType<MessageBus>().As<IMessageBus>().SingleInstance();
			containerBuilder.RegisterType<LogfileParser>().As<ILogfileParser>();
			containerBuilder.RegisterType<LogFileConverter>().As<ILogFileConverter>();
			containerBuilder.RegisterType<FileWatcher>().As<IFileWatcher>();
			containerBuilder.RegisterType<RaidarUploader>().As<RaidarUploader>();
            containerBuilder.RegisterType<ReportUploader>().As<ReportUploader>();
            containerBuilder.RegisterType<ReportPoster>().As<ReportPoster>();
            containerBuilder.RegisterType<HtmlFileWatcher>().As<IHtmlFileWatcher>();
			containerBuilder.RegisterType<LocalLogParser>().As<ILocalLogParser>();
			containerBuilder.RegisterType<RaidHerosUpdater>().As<IRaidHerosUpdater>();
			containerBuilder.RegisterType<CompressedStrategy>().As<ILogDetectionStrategy>();
			containerBuilder.RegisterType<IniReaderStrategy>().As<ILogDetectionStrategy>();
			containerBuilder.RegisterType<UncompressedStrategy>().As<ILogDetectionStrategy>();
			containerBuilder.RegisterType<WaitStrategy>().As<ILogDetectionStrategy>();
			containerBuilder.RegisterType<MainWindow>();
			containerBuilder.RegisterType<MainViewModel>();

			var container = containerBuilder.Build();
			var app = new App();
			app.InitializeComponent();
			var mainWindow = container.Resolve<MainWindow>();
			app.Run(mainWindow);
		}
	}
}
