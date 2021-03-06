// $Id$
// 
// Smuxi - Smart MUltipleXed Irc
// 
// Copyright (c) 2010 Mirco Bauer <meebey@meebey.net>
// 
// Full GPL License: <http://www.gnu.org/licenses/gpl.txt>
// 
// This program is free software; you can redistribute it and/or modify
// it under the terms of the GNU General Public License as published by
// the Free Software Foundation; either version 2 of the License, or
// (at your option) any later version.
// 
// This program is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.
// 
// You should have received a copy of the GNU General Public License
// along with this program; if not, write to the Free Software
// Foundation, Inc., 59 Temple Place, Suite 330, Boston, MA  02111-1307 USA

using System;
using System.Collections.Generic;
using Smuxi.Common;
using Smuxi.Engine;

namespace Smuxi.Frontend.Gnome
{
    public partial class ServerDialog : Gtk.Dialog
    {
        public ServerDialog(Gtk.Window parent, ServerModel server,
                            IList<string> supportedProtocols,
                            IList<string> networks) :
                       base(null, parent, Gtk.DialogFlags.DestroyWithParent)
        {
            Trace.Call(parent, server, supportedProtocols, networks);

            if (parent == null) {
                throw new ArgumentNullException("parent");
            }
            if (supportedProtocols == null) {
                throw new ArgumentNullException("supportedProtocols");
            }
            if (networks == null) {
                throw new ArgumentNullException("networks");
            }

            Build();
            TransientFor = parent;

            f_Widget.InitProtocols(supportedProtocols);
            f_Widget.InitNetworks(networks);

            f_Widget.ProtocolComboBox.Changed += delegate {
                CheckOkButton();
            };
            f_Widget.HostnameEntry.Changed += delegate {
                CheckOkButton();
            };
            CheckOkButton();

            if (server != null) {
                try {
                    f_Widget.Load(server);
                } catch (Exception) {
                    Destroy();
                    throw;
                }
            }
        }

        protected virtual void CheckOkButton()
        {
            Trace.Call();

            f_OkButton.Sensitive = true;
            switch (f_Widget.ProtocolComboBox.ActiveText) {
                case "Campfire":
                    if (f_Widget.HostnameEntry.Text == ".campfirenow.com") {
                        f_OkButton.Sensitive = false;
                    }
                    break;
            }
        }

        public ServerModel GetServer()
        {
            return f_Widget.GetServer();
        }
    }
}
