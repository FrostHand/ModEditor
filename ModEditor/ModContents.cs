﻿using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using System.Xml.Serialization;

namespace ModEditor
{
    public class ModContents
    {
        public TreeView treeView;
        public TreeNode rootTreeNode;

        public Ship_Game.ModInformation modInfo;

        public List<ModContents.Controller> controllers = new List<Controller>();

        public enum State
        {
            Empty,
            Unloaded,
            Loaded 
        }

        public State state = State.Empty;

        ModInfoController modInfoController = new ModInfoController();

        public ModContents(TreeView treeView)
        {
            this.treeView = treeView;
            //this.treeView.Nodes.Clear();
            //rootBase = new TreeNode("Base");
            rootTreeNode = new TreeNode("Root Node");
            //treeView.Nodes.Clear();
            //treeView.Nodes.Add(rootBase);
            treeView.Nodes.Add(rootTreeNode);
            Reset();

            AddController(new ModContents.ArtifactsSpec());
            AddController(new ModContents.EventsGroup());
            AddController(new ModContents.HullsGroup());
            AddController(new ModContents.BuildingSpec());
            AddController(new ModContents.ModuleSpec());            
            AddController(new ModContents.TechSpec());
            AddController(new ModContents.TexturesGroup());
            AddController(new ModContents.TroopSpec());
            AddController(new ModContents.WeaponGroup());

            AddController(modInfoController);
            AddController(new ModContents.StringsGroup());
            /*
             * ModInfo
             	Races
	            Encounters 
             * ToolTips
             */
        }

        public bool Loaded()
        {
            return state == State.Loaded;
        }

        protected bool LoadModInfo(string ModEntryPath)
        {
            try
            {
                FileInfo FI = new FileInfo(ModEntryPath);
                Stream file = FI.OpenRead();
                modInfo = (Ship_Game.ModInformation)Ship_Game.ResourceManager.ModSerializer.Deserialize(file);
                modInfoController.rootItem.target = modInfo;
                rootTreeNode.Name = modInfo.ModName;
                rootTreeNode.Text = modInfo.ModName;
                file.Close();
                file.Dispose();
                return true;
            }
            catch (Exception e)
            {
            }
            return false;
        }

        protected bool SaveModInfo(string ModEntryPath)
        {
            try
            {
                FileInfo FI = new FileInfo(ModEntryPath);
                Stream file = FI.OpenWrite();
                Ship_Game.ResourceManager.ModSerializer.Serialize(file, modInfo);
                file.Close();
                file.Dispose();
                return true;
            }
            catch (Exception e)
            {
            }
            return false;
        }

        public void SaveMod(string ModEntryPath)
        {            
            SaveModInfo("Mods/" + ModEntryPath);
            string outputDir = "Mods/" + System.IO.Path.GetDirectoryName(ModEntryPath) + "\\" + Path.GetFileNameWithoutExtension(ModEntryPath);
            System.IO.Directory.CreateDirectory(outputDir);
            foreach (var controller in controllers)
            {
                controller.Save(outputDir);
            }            
        }

        public void SetName(string Name)
        {
            if (modInfo != null)
                modInfo.ModName = Name;
            rootTreeNode.Name = Name;
            rootTreeNode.Text = Name;
        }

        protected void AddController(Controller controller)
        {
            controllers.Add(controller);
        }

        public void LoadMod(string ModEntryPath)
        {
            try
            {
                string modRootDirectory = "Mods";
                string modDirectory = modRootDirectory + "\\" + Path.GetFileNameWithoutExtension(ModEntryPath);
                LoadModInfo(ModEntryPath);
                // 1. Load contents                
                Ship_Game.ResourceManager.LoadMods(modDirectory);
                // 2. Populate treeview
                PopulateData(false);
                
                state = State.Loaded;
            }
            catch (Exception e)
            {
            }
        }

        public void Reset()
        {
            //rootBase.Nodes.Clear();// = null;
            rootTreeNode.Nodes.Clear();// = null;
            
            //treeView.Nodes.Clear();
            //treeView.Nodes.Add("Load mod to observe data");
            foreach (var controller in controllers)
            {
                controller.ClearCache();
            }

            modInfo = null;
        }

        public void PopulateData(bool isBase)
        {
            foreach (var controller in controllers)
            {
                controller.ObtainModData(isBase);
                controller.PopulateModOverview(rootTreeNode.Nodes);
            }                                  
        }

        public void UpdateUI()
        {
            foreach (var controller in controllers)
            {
                controller.UpdateItems();                
            } 
        }
        #region Tools

        public static FileInfo[] GetFilesFromDirectory(string DirPath)
        {
            DirectoryInfo Dir = new DirectoryInfo(DirPath);
            FileInfo[] result;
            try
            {
                FileInfo[] FileList = Dir.GetFiles("*.*", SearchOption.AllDirectories);

                result = FileList;
            }
            catch
            {
                result = new FileInfo[0];
            }
            return result;
        }

        public static DirectoryInfo[] GetDirectoriesFromDirectory(string DirPath)
        {
            DirectoryInfo Dir = new DirectoryInfo(DirPath);
            DirectoryInfo[] result;
            try
            {
                DirectoryInfo[] DirList = Dir.GetDirectories();//("*.*", SearchOption.AllDirectories);

                result = DirList;
            }
            catch
            {
                result = new DirectoryInfo[0];
            }
            return result;
        }

        private const int TVIF_STATE = 0x8;
        private const int TVIS_STATEIMAGEMASK = 0xF000;
        private const int TV_FIRST = 0x1100;
        private const int TVM_SETITEM = TV_FIRST + 63;

        [StructLayout(LayoutKind.Sequential, Pack = 8, CharSet = CharSet.Auto)]
        private struct TVITEM
        {
            public int mask;
            public IntPtr hItem;
            public int state;
            public int stateMask;
            [MarshalAs(UnmanagedType.LPTStr)]
            public string lpszText;
            public int cchTextMax;
            public int iImage;
            public int iSelectedImage;
            public int cChildren;
            public IntPtr lParam;
        }

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern IntPtr SendMessage(IntPtr hWnd, int Msg, IntPtr wParam,
                                                 ref TVITEM lParam);

        /// <summary>
        /// Hides the checkbox for the specified node on a TreeView control.
        /// </summary>
        public static void HideCheckBox(TreeNode node)
        {
            TreeView tvw = node.TreeView;
            if (tvw == null)
                return;
            TVITEM tvi = new TVITEM();
            tvi.hItem = node.Handle;
            tvi.mask = TVIF_STATE;
            tvi.stateMask = TVIS_STATEIMAGEMASK;
            tvi.state = 0;
            SendMessage(tvw.Handle, TVM_SETITEM, IntPtr.Zero, ref tvi);
            
        }
       
        static public string EmbedToString<Type>(string source, Type obj)
        {
            Regex rx = new Regex("\\$\\{(\\w+)\\.(\\w+)\\}"); 
           
            var TypeInfo = typeof(Type);

            /// for each match calls lambda to evaluate replacement string
            string result = rx.Replace(source, (Match match)=>
            {
                string className = match.Groups[1].Value;
                string fieldName = match.Groups[2].Value;
                if (className.Equals(TypeInfo.Name))
                {
                    try
                    {
                        /// Obtain string value from specified field
                        return TypeInfo.GetField(fieldName).GetValue(obj).ToString();
                    }
                    catch (Exception)
                    {
                        /// Cannot access <fieldName>
                    }
                }
                else
                {
                /// Do not do anything with data from other class
                }
                return match.ToString();
            });           
            
            return result;        
        }
        #endregion
        /// <summary>
        /// Wraps item, i.e Tech or Device, stores active ui information concerned to selected node
        /// </summary>
        public class ItemBase
        {
            public Controller controller;
            public Object target;            
            public ItemBase prev, next;

            public bool isBase;

            public ItemBase(Object item, Controller controller)
            {
                target = item;
                this.controller = controller;
            }

            public bool Modded()
            {
                return next != null;
            }

            public virtual Object getTarget()
            {
                return target;
            }

            public ContextMenuStrip GenerateContextMenu()
            {
                return controller.GenerateContextMenu(this);
            }

            public Control GenerateControl()
            {
                return controller.GenerateControl(this);
            }

            // remove links with other items
            public void UnLink()
            {
                if (prev != null)
                    prev.next = next;
                if (next != null)
                    next.prev = prev;
            }

            public void UpdateUI()
            {
                if (Modded() && node != null)
                    node.BackColor = System.Drawing.Color.YellowGreen;
            }

            public string name;
            public TreeNode node;       /// Assigned tree node
            public TabPage page;        /// Assigned tab page
        }

        /// <summary>
        /// Defines methods to interact with specific mod objects
        /// </summary>
        public abstract class Controller
        {
            public ItemBase rootItem;
            public Controller()
            {
                rootItem = new ItemBase(null, this);
                rootItem.controller = this;
            }

            public virtual ItemBase CreateSpec(Object obj)
            {
                return new ItemBase(obj, this);
            }

            public virtual string GetGroupFolder()
            {
                return ".";
            }

            public abstract void ClearCache();
            public abstract Control GenerateControl(ItemBase item);
            public virtual ContextMenuStrip GenerateContextMenu(ItemBase item)
            {
                return null;
            }
            public abstract void ObtainModData(bool isBase);
            public abstract void PopulateModOverview(TreeNodeCollection root);
            public abstract void Save(string dir);

            public abstract void UpdateItems();
        }

        public class ModInfoController : Controller
        {
            public ModInfoController()
            {
                rootItem.name = "ModInfo";             
            }

            public override void ClearCache()
            {

            }            

            private void OnNewItem(object sender, EventArgs e)
            {
                throw new NotImplementedException();
            }

            public override Control GenerateControl(ItemBase item)
            {                
                if(item.target == null)
                    return null;
                ItemExplorer explorer = new ItemExplorer();
                Ship_Game.ModInformation targetObj = (Ship_Game.ModInformation)item.target;
                explorer.Init(targetObj);
                return explorer;
            }

            public override void ObtainModData(bool isBase)
            {               
            }

            public override void PopulateModOverview(TreeNodeCollection root)
            {
                if (rootItem == null)
                    return;
                TreeNode groupNode = null;
                string folder = "ModInfo";
                if (root.ContainsKey(folder))
                    groupNode = root[folder];
                else
                {
                    groupNode = new TreeNode(folder);
                    root.Add(groupNode);
                }
                groupNode.Tag = rootItem;
                rootItem.node = groupNode;
            }

            public override void Save(string dir)
            {
            }

            public override void UpdateItems()
            {
            }
        }
        
        public class StringsGroup : Controller
        {
            static DataTable globalStrings = new DataTable();
            DataTable localStrings = new DataTable();
            DataColumn localColumnTokens;

            public StringsGroup()
            {
                rootItem.name = "Strings";
                localColumnTokens = new DataColumn("token", typeof(int));
                localColumnTokens.Unique = true;
                localStrings.Columns.Add(localColumnTokens);
                localStrings.PrimaryKey = new DataColumn[] { localColumnTokens };
//                dt.Columns.Add(new DataColumn("text", typeof(string)));
//                dt.Columns.Add(new DataColumn("refs", typeof(int)));                  
            }

            public override void ClearCache()
            { 

            }

            public override ContextMenuStrip GenerateContextMenu(ItemBase item)
            {
                ContextMenuStrip result = new ContextMenuStrip();
                if (item.Equals(rootItem))
                {
                    result.Items.Add("New Language", null, OnNewItem);
                }
                else
                {                    
                    result.Items.Add("Delete", null, OnDeleteItem);
                }
                return result;
            }

            private void OnDeleteItem(object sender, EventArgs e)
            {
            }

            private void OnNewItem(object sender, EventArgs e)
            {
            }

            public override Control GenerateControl(ItemBase item)
            {
                DataGridView result = new DataGridView();
                result.DataSource = localStrings;
                result.Dock = DockStyle.Fill;
                result.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
                //result.Columns["text"].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                return result;
            }

            private Ship_Game.LocalizationFile LoadLanguage(string language)
            {
                FileInfo[] textList = GetFilesFromDirectory(language);
                XmlSerializer serializer = new XmlSerializer(typeof(Ship_Game.LocalizationFile));
                FileInfo[] array = textList;
                Ship_Game.LocalizationFile result = null;
                for (int i = 0; i < array.Length; i++)
                {
                    FileInfo FI = array[i];
                    FileStream stream = FI.OpenRead();
                    Ship_Game.LocalizationFile data = (Ship_Game.LocalizationFile)serializer.Deserialize(stream);
                    stream.Close();
                    stream.Dispose();
                    result = data;
                    //Ship_Game.ResourceManager.LanguageFile = data;
                }
                //Ship_Game.Localizer.FillLocalizer();
                return result;
            }

            private void ProcessLanguage(Ship_Game.LocalizationFile data, string language)
            {
                DataColumn columnValue = null;
                                
                if (!localStrings.Columns.Contains(language))
                {
                    columnValue = localStrings.Columns.Add(language, typeof(string));
                }
                else
                    columnValue = localStrings.Columns[language];
                int rowsCount = localStrings.Rows.Count;

                foreach (var entry in data.TokenList)
                {
                    //string expression = String.Format("token Like  {0}", entry.Index);
                    DataRow row = localStrings.Rows.Find(entry.Index);
                                        
                    if (row == null)
                    {
                        row = localStrings.NewRow();
                        //row.BeginEdit();
                        row[columnValue] = entry.Text;
                        row[localColumnTokens] = entry.Index;
                        localStrings.Rows.Add(row);
                        //row.EndEdit();
                    }
                    else
                    {
                        row[columnValue] = entry.Text;
                    }
                }
            }

            public override void ObtainModData(bool isBase)
            {                
                foreach (var dir in GetDirectoriesFromDirectory(Ship_Game.ResourceManager.WhichModPath + "/Localization/"))
                {
                    var data = LoadLanguage(dir.FullName);
                    if (data != null)
                        ProcessLanguage(data, dir.Name);
                }
		/*
                foreach (var item in Ship_Game.Localizer.LocalizerDict)
                {
                    object[] row = { item.Key, item.Value, 0 };
                    localStrings.Rows.Add(row);
                }*/
            }

            public override void PopulateModOverview(TreeNodeCollection root)
            {
                TreeNode groupNode = null;
                string folder = "Strings";
                if (root.ContainsKey(folder))
                    groupNode = root[folder];
                else
                {
                    groupNode = new TreeNode(folder);
                    root.Add(groupNode);
                }
                groupNode.Tag = rootItem;
                rootItem.node = groupNode;
            }

            public override void Save(string dir)
            {
            }

            public override void UpdateItems()
            { 
            }
        }

        public abstract class ControllerSpec<Target> : Controller
        {            
            // Global items cache            
            public static Dictionary<string, ItemBase> globalCache = new Dictionary<string, ItemBase>();
            // Local cache for items created by this mod
            public Dictionary<string, ItemBase> localCache = new Dictionary<string, ItemBase>();

            public override void UpdateItems()
            {
                foreach (var record in localCache)
                {
                    record.Value.UpdateUI();
                }
            }

            public override void ClearCache()
            {
                localCache.Clear();
            }

            public override ContextMenuStrip GenerateContextMenu(ItemBase item)
            {
                ContextMenuStrip result = new ContextMenuStrip();
                if (item.Equals(rootItem))
                {
                    result.Items.Add("New", null, OnNewItem);
                }
                else
                {
                    result.Items.Add("Copy", null, OnCopyItem);
                    result.Items.Add("Delete", null, OnDeleteItem);
                }
                return result;
            }

            private void OnDeleteItem(object sender, EventArgs e)
            {
                
            }

            private void OnCopyItem(object sender, EventArgs e)
            {
            }

            private void OnNewItem(object sender, EventArgs e)
            {

            }

            public abstract Dictionary<string, Target> GetStorage();

            public virtual XmlSerializer GetSerializer()
            {
                return new XmlSerializer(typeof(Target));
            }

            public override void Save(string rootDir)
            {               
                XmlSerializer serializer = GetSerializer();
                if(serializer == null)
                    return;
                var data = GetStorage();

                System.IO.Directory.CreateDirectory(rootDir + "/" + GetGroupFolder());

                foreach (var item in localCache)
                {
                    string path = rootDir + "/" + GetGroupFolder() + "/" + item.Key + ".xml";
                    FileInfo FI = new FileInfo(path);
                    FileStream stream = FI.OpenWrite();
                    Target value = (Target)item.Value.target;
                    serializer.Serialize(stream, value);
                    stream.Close();
                    stream.Dispose();
                }
            }

            public override Control GenerateControl(ItemBase item)
            {
                if (item.Equals(rootItem))
                    return null;
                ItemExplorer explorer = new ItemExplorer();
                Target targetObj = (Target)item.target;
                explorer.Init(targetObj);
                return explorer;
            }

            /// <summary>
            /// Iterate through cache and show data
            /// </summary>
            /// <param name="root"></param>
            public override void PopulateModOverview(TreeNodeCollection root)
            {
                TreeNode groupNode = null;
                string folder = this.GetGroupFolder();
                if (root.ContainsKey(folder))
                    groupNode = root[folder];
                else
                {
                    groupNode = new TreeNode(folder);
                    root.Add(groupNode);
                }

                groupNode.Tag = rootItem;
                rootItem.node = groupNode;

                foreach (var entry in localCache)
                {
                    if (entry.Value.node == null)
                    {
                        TreeNode node = new TreeNode(entry.Key);
                        entry.Value.node = node;
                        node.Tag = entry.Value;
                        groupNode.Nodes.Add(node);
                    }                    
                }
            }
            /// <summary>
            /// Iterate through all items in dictionary and add them to overview
            /// </summary> 
            public override void ObtainModData(bool isBase)
            {              
                var data = GetStorage();
               
                foreach (var entry in data)
                {                   
                    ItemBase item = null;

                    if (globalCache.ContainsKey(entry.Key))
                    {
                        ItemBase oldItem = globalCache[entry.Key];
                        // found the same item
                        if (oldItem.target.Equals(entry.Value))
                            continue;

                        item = CreateSpec(entry.Value);
                        item.name = entry.Key;                        
                        
                        localCache.Add(entry.Key, item);
                        item.prev = oldItem;
                        oldItem.next = item;

                        globalCache[entry.Key] = item;
                    }
                    else
                    {
                        /// add item to both global and local cache
                        item = CreateSpec(entry.Value);
                        item.name = entry.Key;
                        item.isBase = isBase;
                        globalCache.Add(entry.Key, item);
                        localCache.Add(entry.Key, item);
                    }                                   
                }
            }
        }       

        public class WeaponGroup : ControllerSpec<Ship_Game.Gameplay.Weapon>
        {
            public override XmlSerializer GetSerializer()
            {
                return Ship_Game.ResourceManager.weapon_serializer;
            }           
            
            public override Dictionary<string, Ship_Game.Gameplay.Weapon> GetStorage()
            {
                return Ship_Game.ResourceManager.WeaponsDict;
            }

            public override string GetGroupFolder()
            {
                return "Weapons";
            }            
        }

        public class TexturesGroup : ControllerSpec<Texture2D>
        {
            public override XmlSerializer GetSerializer()
            {
                return null;
            }

            public override Dictionary<string, Texture2D> GetStorage()
            {
                return Ship_Game.ResourceManager.TextureDict;
            }

            public override string GetGroupFolder()
            {
                return "Textures";
            }
        }

        public class EventsGroup : ControllerSpec<Ship_Game.ExplorationEvent>
        {
            public override XmlSerializer GetSerializer()
            {
                return Ship_Game.ResourceManager.weapon_serializer;
            }

            public override Dictionary<string, Ship_Game.ExplorationEvent> GetStorage()
            {
                return Ship_Game.ResourceManager.EventsDict;
            }

            public override string GetGroupFolder()
            {
                return "Exploration Events";
            }
        }

        /*
        public class RacesGroup : ControllerSpec<Ship_Game.ShipData>
        {
            public override XmlSerializer GetSerializer()
            {
                return Ship_Game.ResourceManager.weapon_serializer;
            }

            public override Dictionary<string, Ship_Game.ShipData> GetStorage()
            {
                return Ship_Game.ResourceManager.HullsDict;
            }

            public override string GetGroupFolder()
            {
                return "Races";
            }
        }*/

        public class HullsGroup : ControllerSpec<Ship_Game.ShipData>
        {
            public override XmlSerializer GetSerializer()
            {
                return Ship_Game.ResourceManager.weapon_serializer;
            }

            public override Dictionary<string, Ship_Game.ShipData> GetStorage()
            {
                return Ship_Game.ResourceManager.HullsDict;
            }

            public override string GetGroupFolder()
            {
                return "Hulls";
            }
        }

        public class TechSpec : ControllerSpec<Ship_Game.Technology>
        {            
            override public Dictionary<string, Ship_Game.Technology> GetStorage()
            {
                return Ship_Game.ResourceManager.TechTree;
            }

            public override string GetGroupFolder()
            {
                return "Technology";
            }

        }

        public class TroopSpec : ControllerSpec<Ship_Game.Troop>
        {
            override public Dictionary<string, Ship_Game.Troop> GetStorage()
            {
                return Ship_Game.ResourceManager.TroopsDict;
            }

            override public string GetGroupFolder()
            {
                return "Troops";
            }
        }

        public class BuildingSpec : ControllerSpec<Ship_Game.Building>
        {
            override public Dictionary<string, Ship_Game.Building> GetStorage()
            {
                return Ship_Game.ResourceManager.BuildingsDict;
            }

            override public string GetGroupFolder()
            {
                return "Buildings";
            }
        }

        public class ArtifactsSpec : ControllerSpec<Ship_Game.Artifact>
        {
            #region Static overrides
            override public Dictionary<string, Ship_Game.Artifact> GetStorage()
            {
                return Ship_Game.ResourceManager.ArtifactsDict;
            }

            override public string GetGroupFolder()
            {
                return "Artifacts";
            }

            #endregion
        }

        public class ModuleSpec : ControllerSpec<Ship_Game.Gameplay.ShipModule>
        {
            /*
            public override XmlSerializer GetSerializer()
            {
                return Ship_Game.ResourceManager.ModSerializer;
            } */

            override public Dictionary<string, Ship_Game.Gameplay.ShipModule> GetStorage()
            {
                return Ship_Game.ResourceManager.ShipModulesDict;
            }

            override public string GetGroupFolder()
            {
                return "ShipModules";
            }
        }
    }
}
