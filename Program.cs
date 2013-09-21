//
//  Program.cs
//
//  Author:
//       Willem Van Onsem <vanonsem.willem@gmail.com>
//
//  Copyright (c) 2013 Willem Van Onsem
//
//  This program is free software: you can redistribute it and/or modify
//  it under the terms of the GNU General Public License as published by
//  the Free Software Foundation, either version 3 of the License, or
//  (at your option) any later version.
//
//  This program is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY; without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//  GNU General Public License for more details.
//
//  You should have received a copy of the GNU General Public License
//  along with this program.  If not, see <http://www.gnu.org/licenses/>.
using System;
using System.Collections.Generic;
using System.IO;
using Mono.Options;
using ZincOxide.Parser;

namespace ZincOxide {

    public class Program {

        public static int Main (string[] args) {
            bool show_help = false;
            ProgramEnvironment environment = new ProgramEnvironment ();
            var p = new OptionSet () {
                {"t|task=","The task to be executed (validate-model,validate-data,match,generate-data,generate-heuristics,assume).",x => environment.Task = ProgramUtils.ParseTask(x)},
                {"v|verbosity=","The level of verbosity (error,warning,assumption,remark).",x => environment.Verbosity = ProgramUtils.ParseVersbosity(x)},
                {"h|help","Show this help message and exit.", x => show_help = x != null}
            };

            List<string> files = new List<string> ();
            try {
                files = p.Parse (args);
            } catch (OptionException e) {
                Console.Write ("zincoxide: ");
                Console.WriteLine (e.Message);
                Console.WriteLine ("Try 'zincoxide --help' for more information.");
                return (int)ProgramResult.StaticError;
            } catch (ZincOxideException e) {
                Interaction.SetLevel (environment.Verbosity);
                Interaction.Error (e.Message);
                return (int)ProgramResult.StaticError;
            }

            if (show_help) {
                Console.WriteLine ("Usage: zincoxide [Options]+ files");
                Console.WriteLine ();
                Console.WriteLine ("Options: ");
                p.WriteOptionDescriptions (Console.Out);
            } else {
                DirectoryInfo dirInfo = new DirectoryInfo (".");
                foreach (string name in files) {
                    FileInfo[] fInfo = dirInfo.GetFiles (name);
                    foreach (FileInfo info in fInfo) {
                        try {
                            using (FileStream file = new FileStream (info.FullName, FileMode.Open)) {
                                MiniZincLexer scnr = new MiniZincLexer (file);
                                MiniZincParser pars = new MiniZincParser (scnr);

                                Console.WriteLine ("File: " + info.Name);
                                /*foreach (Token tok in scnr.Tokenize()) {
                                    Console.Write (tok);
                                    Console.Write (' ');
                                }*/
                                pars.Parse ();
                                if (pars.Result != null) {
                                    Console.WriteLine ("echo: ");
                                    pars.Result.Write (Console.Out);
                                } else {
                                    Interaction.Warning ("File \"{0}\" is not a valid MiniZinc file.");
                                }
                            }
                        } catch (IOException) {
                            Interaction.Warning ("File \"{0}\" not found.", info.Name);
                        }
                    }
                }
            }
            return (int)ProgramResult.Succes;
        }

    }
}
