using Microsoft.Owin.Hosting;
using Owin;
using System;
using System.Net.Http.Formatting;
using System.Web.Http;
using Topshelf;

namespace DummyWebApi
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var config = ConfigureApi();
            app.UseWebApi(config);
        }

        private HttpConfiguration ConfigureApi()
        {
            var config = new HttpConfiguration();
            config.Formatters.Clear();
            config.Formatters.Add(new JsonMediaTypeFormatter());
            config.Formatters.Add(new XmlMediaTypeFormatter());
            config.EnableCors();
            config.Routes.MapHttpRoute(
                "DefaultApi",
                "api/{controller}/{id}",
                new { id = RouteParameter.Optional });
            return config;
        }
    }
    public class DummyService
    {
        private IDisposable _app;

        public void Start()
        {
            _app = WebApp.Start<Startup>("http://localhost:8085");
        }

        public void Stop()
        {
            if (_app != null)
                _app.Dispose();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var rc = HostFactory.Run(x =>                                   //1
            {
                x.Service<DummyService>(s =>                                   //2
                {
                    s.ConstructUsing(name => new DummyService());                //3
                    s.WhenStarted(tc => tc.Start());                         //4
                    s.WhenStopped(tc => tc.Stop());                          //5
                });
                x.RunAsLocalSystem();                                       //6

                x.SetDescription("Sample Topshelf Host");                   //7
                x.SetDisplayName("Stuff");                                  //8
                x.SetServiceName("Stuff");                                  //9
            });                                                             //10

            var exitCode = (int)Convert.ChangeType(rc, rc.GetTypeCode());  //11
            Environment.ExitCode = exitCode;
        }
    }
}
