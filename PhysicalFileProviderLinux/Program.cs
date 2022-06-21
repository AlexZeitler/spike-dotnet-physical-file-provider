// See https://aka.ms/new-console-template for more information

using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Primitives;

PhysicalFileProvider fileProvider;
IChangeToken fileChangeToken;

void WatchForFileChanges()
{
  fileChangeToken = fileProvider.Watch("*.*");
  fileChangeToken.RegisterChangeCallback(Notify, "default");
}

void Notify(object state)
{
  Console.WriteLine("File change detected");
  WatchForFileChanges();
}

fileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), "./watch"));
WatchForFileChanges();

Console.WriteLine("Watching for file changes in ./watch");
Console.WriteLine("Press any key to stop watching.");

Console.ReadKey(false);
