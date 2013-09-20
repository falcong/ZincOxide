//
//  ProgramUtils.cs
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
using System.Text;
using System.Text.RegularExpressions;

namespace ZincOxide {

    public static class ProgramUtils {

        private static readonly Regex rgxVerbosity = new Regex (@"^(([0-9a-f])|((e|w|a|r)*)|(error|warning|assumption|remark))$", RegexOptions.Compiled | RegexOptions.ExplicitCapture | RegexOptions.Singleline | RegexOptions.IgnoreCase);
        private static readonly Regex rgxTask = new Regex (@"^((validate-?model|validate-?data|match|generate-?data|generate-?heuristics|assume|transform|generate-basic))$");

        public static ProgramVerbosity ParseVersbosity (string level) {
            Match m = rgxVerbosity.Match (level);
            if (m.Success) {
                return ProgramVerbosity.Warning;//TODO
            } else {
                throw new ZincOxideException ("Cannot parse verbosity level.");
            }
        }

        public static ProgramTask ParseTask (string task) {
            Match m = rgxTask.Match (task);
            if (m.Success) {
                return ProgramTask.GenerateHeuristics;//TODO
            } else {
                throw new ZincOxideException ("Cannot parse the task to be executed.");
            }
        }


    }
}

