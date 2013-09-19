//
//  ZincOutputItem.cs
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
using System.IO;

namespace ZincOxide.MiniZinc {

    public class ZincOutputItem : ZincExpressionBoxBase, IZincItem {

        #region IZincItem implementation
        public ZincItemType Type {
            get {
                return ZincItemType.Output;
            }
        }
        #endregion

        public ZincOutputItem (IZincExpression expression) : base(expression) {
        }

        public override string ToString () {
            return string.Format ("output {0}", this.Expression);
        }

        #region IWriteable implementation
        public void Write (StreamWriter writer) {
            writer.Write (this.ToString ());
        }
        #endregion



    }
}

