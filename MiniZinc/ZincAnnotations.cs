//
//  ZincAnnotations.cs
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
using System.Linq;
using System.Collections.Generic;
using System.IO;
using ZincOxide.Utils;

namespace ZincOxide.MiniZinc {

    public class ZincAnnotations : LinkedList<ZincAnnotation>, IWriteable, IZincIdentReplaceContainer {

        public ZincAnnotations (IEnumerable<ZincAnnotation> annotations) : base(annotations) {
        }

        public ZincAnnotations (params ZincAnnotation[] annotations) : base(annotations) {
        }

        public override string ToString () {
            return string.Format (":: {0}", string.Join (" :: ", this));
        }

        #region IWriteable implementation
        public void Write (TextWriter writer) {
            writer.Write (this.ToString ());
        }
        #endregion

        #region IZincIdentContainer implementation
        public IEnumerable<ZincIdent> InvolvedIdents () {
            return this.SelectMany (x => x.InvolvedIdents ());
        }
        #endregion

        #region IZincIdentReplaceContainer implementation
        public IZincIdentReplaceContainer Replace (IDictionary<ZincIdent, ZincIdent> identMap) {
            LinkedListNode<ZincAnnotation> node = this.First;
            while (node != null) {
                node.Value = node.Value.Replace (identMap) as ZincAnnotation;
                node = node.Next;
            }
            return this;
        }
        #endregion



    }
}

