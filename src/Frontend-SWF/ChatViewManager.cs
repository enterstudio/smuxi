/*
 * $Id: ChannelPage.cs 138 2006-12-23 17:11:57Z meebey $
 * $URL: svn+ssh://svn.qnetp.net/svn/smuxi/smuxi/trunk/src/Frontend-GNOME/ChannelPage.cs $
 * $Rev: 138 $
 * $Author: meebey $
 * $Date: 2006-12-23 18:11:57 +0100 (Sat, 23 Dec 2006) $
 *
 * smuxi - Smart MUltipleXed Irc
 *
 * Copyright (c) 2005-2006 Mirco Bauer <meebey@meebey.net>
 *
 * Full GPL License: <http://www.gnu.org/licenses/gpl.txt>
 *
 * This program is free software; you can redistribute it and/or modify
 * it under the terms of the GNU General Public License as published by
 * the Free Software Foundation; either version 2 of the License, or
 * (at your option) any later version.
 *
 * This program is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 * GNU General Public License for more details.
 *
 * You should have received a copy of the GNU General Public License
 * along with this program; if not, write to the Free Software
 * Foundation, Inc., 59 Temple Place, Suite 330, Boston, MA  02111-1307 USA
 */

using System;
using System.Globalization;
using Mono.Unix;
using Smuxi.Common;
using Smuxi.Engine;
using Smuxi.Frontend;

namespace Smuxi.Frontend.Swf
{
    public class ChatViewManager : ChatViewManagerBase
    {
#if LOG4NET
        private static readonly log4net.ILog _Logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
#endif
        private Notebook     _Notebook;
        //private UserConfig   _Config;
        
        public override IChatView ActiveChat {
            get {
                return _Notebook.CurrentChatView;
            }
        }
        
        public ChatViewManager(Notebook notebook /*, UserConfig userConfig*/)
        {
            _Notebook = notebook;
            //_Config = userConfig;
        }
        
        public override void AddChat(ChatModel chat)
        {
            ChatView chatView = (ChatView) CreateChatView(chat);
            //_Notebook.Controls.Add(chatView);
            _Notebook.TabPages.Add(chatView);
        }
        
        public override void RemoveChat(ChatModel chat)
        {
            ChatView chatView = _Notebook.GetChat(chat);
            //_Notebook.Controls.Remove(chatView);
            _Notebook.TabPages.Remove(chatView);
        }
        
        public override void EnableChat(ChatModel chat)
        {
            ChatView chatView = _Notebook.GetChat(chat);
            chatView.Enable();
        }
        
        public override void DisableChat(ChatModel chat)
        {
            ChatView chatView = _Notebook.GetChat(chat);
            chatView.Disable();
        }
        
        public ChatView GetChat(ChatModel chatModel)
        {
            return _Notebook.GetChat(chatModel);
        }
    }
}
