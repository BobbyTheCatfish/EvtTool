using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace EvtTool
{
    internal static class Program
    {
        private static void Main( string[] args )
        {
            //var uniqueValues = new Dictionary<string, HashSet<object>>();

            //foreach ( var file in Directory.EnumerateFiles( @"D:\Users\smart\Documents\Visual Studio 2017\Projects\DumpEVTFiles\DumpEVTFiles\bin\Debug\evts", "*.EVT" ) )
            //{
            //    var evt = new EvtFile( file );
            //    foreach ( var command in evt.Commands )
            //    {
            //        if ( command.Type == "Msg_" )
            //        {
            //            foreach ( var field in typeof( MsgCommandData ).GetProperties() )
            //            {
            //                if ( !uniqueValues.ContainsKey( field.Name ) )
            //                    uniqueValues[ field.Name ] = new HashSet<object>();

            //                uniqueValues[ field.Name ].Add( field.GetValue( command.Data ) );
            //            }
            //        }
            //    }
            //}

            //foreach ( var field in uniqueValues.Keys )
            //{
            //    Console.Write( $"{field}:" );
            //    foreach ( var o in uniqueValues[field] )
            //    {
            //        Console.Write( $" {o}," );
            //    }
            //    Console.WriteLine(  );
            //}
            //return;


            string path = null;
            var outputToConsole = false;
            bool reduced = true;
            var filesettings = StringComparison.InvariantCultureIgnoreCase;

            foreach ( var arg in args )
            {
                if ( arg == "--no-output" )
                {
                    outputToConsole = true;
                }
                else if (arg == "--full")
                {
                    reduced = false;
                }
                else if ( path == null )
                {
                    path = arg;
                }
            }
            if ( path == null )
            {
                Console.WriteLine( "EvtTool 1.4 by TGE\n" +
                                   "\n" +
                                   "Usage:\n" +
                                   "EvtTool <file path>\n" +
                                   "Drag .EVT, .ECS or .lsd file onto the program to convert to JSON, drag JSON file to convert back.\n\n" +
                                   "Flags:\n" +
                                   "--no-output     Prints the output to the console instead of creating a file\n" +
                                   "--full          Includes unused and static values in command data");
                return;
            }
            if ( !File.Exists( path ) )
            {
                Console.WriteLine( "Specified file doesn't exist." );
                return;
            }

            if ( path.EndsWith( "json", filesettings ) )
            {
                var json = File.ReadAllText( path );
                ISaveable file;
                var settings = new JsonSerializerSettings { MissingMemberHandling = MissingMemberHandling.Error, NullValueHandling = NullValueHandling.Include, DefaultValueHandling = DefaultValueHandling.Populate };

                try
                {
                    if ( path.EndsWith( ".EVT.json", filesettings ) )
                    {
                        file = JsonConvert.DeserializeObject<EvtFile>( json, settings );
                    }
                    else if ( path.EndsWith( ".ECS.json", filesettings ) )
                    {
                        file = JsonConvert.DeserializeObject<EcsFile>( json, settings );
                    }
                    else if ( path.EndsWith( ".lsd.json", filesettings ) )
                    {
                        file = new LsdFile( JsonConvert.DeserializeObject<List<LsdList>>( json, settings ) );
                    }
                    else
                    {
                        Console.WriteLine(
                            "Unrecognized source file type. Did you alter the extension of the file? Expected name format is 'filename.format.json'" );
                        return;
                    }
                }
                catch ( Exception )
                {
                    Console.WriteLine( "Error occured while deserializing JSON. The JSON provided is either corrupt or incompatible." );
                    return;
                }
                if ( outputToConsole == true )
                {
                    Console.WriteLine( file.ToString() );
;                   return;
                }
                file.Save( Path.ChangeExtension( path, null ) );
            }
            else
            {
                var extension = "EVT.json";
                object obj;
                var settings = new JsonSerializerSettings
                {
                    MissingMemberHandling = MissingMemberHandling.Error,
                    Formatting = Formatting.Indented,
                    NullValueHandling = reduced ? NullValueHandling.Ignore : NullValueHandling.Include,
                    DefaultValueHandling = reduced ? DefaultValueHandling.Ignore : DefaultValueHandling.Populate
                };

                if ( path.EndsWith( "evt", filesettings ) )
                {
                    obj = new EvtFile( path );
                }
                else if ( path.EndsWith( "ecs", filesettings) )
                {
                    obj = new EcsFile( path );
                    extension = "ECS.json";
                }
                else if ( path.EndsWith( "lsd", filesettings ) )
                {
                    obj = new LsdFile( path ).Lists;
                    extension = "lsd.json";
                }
                else
                {
                    Console.WriteLine( "Unrecognized file type." );
                    return;
                }

                var json = JsonConvert.SerializeObject( obj, settings );
                if ( outputToConsole == true )
                {
                    Console.WriteLine( json );
                    return;
                }
                File.WriteAllText( Path.ChangeExtension( path, extension ), json );
            }
        }
    }
}