﻿//
// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
//

// This file was generated by a T4 Template. Do not modify directly, instead update the ObjectExplorerModel.xml
// and re-run the T4 template (ObjectExplorerModel.tt). This can be done in Visual Studio by right-click in and choosing "Run Custom Tool",
// or from the command-line on any platform by running "build.cmd -Target=CodeGen" or "build.sh -Target=CodeGen".

using System.Collections.Generic;

namespace Microsoft.SqlTools.SqlCore.SimpleObjectExplorer
{
	/// <summary>
	/// Database Node
	/// </summary>
	public class DatabaseNode : TreeNode
	{
		public DatabaseNode(TreeNode parent, ObjectMetadata metadata) : base(parent, metadata, false)
		{
			Type = NodeTypes.Database;
			IsLeaf = false;
			ScriptingObject.Type = "Database";
		}

		public override void  LoadChildren(ObjectMetadata[] metadata)
		{
			this.Children = new List<TreeNode>();
			foreach(ObjectMetadata child in metadata)
			{
				if (child.Type == "Schema" && child.Parent == this.Name)
				{
					Children.Add(new SchemaNode(this, child));
				}
			}
		}
	}
	/// <summary>
	/// Schema Node
	/// </summary>
	public class SchemaNode : TreeNode
	{
		public SchemaNode(TreeNode parent, ObjectMetadata metadata) : base(parent, metadata, false)
		{
			Type = NodeTypes.Schema;
			IsLeaf = false;
			ScriptingObject.Type = "Schema";
		}

		public override void  LoadChildren(ObjectMetadata[] metadata)
		{
			this.Children = new List<TreeNode>();
			Children.Add(new TablesFolder(this));
			Children.Add(new ViewsFolder(this));
			Children.Add(new StoredProceduresFolder(this));
			Children.Add(new FunctionsFolder(this));
			Children.Add(new ShortcutsFolder(this));
		}
	}
	/// <summary>
	/// Table Node
	/// </summary>
	public class TableNode : TreeNode
	{
		public TableNode(TreeNode parent, ObjectMetadata metadata) : base(parent, metadata, false)
		{
			Type = NodeTypes.Table;
			IsLeaf = false;
			ScriptingObject.Type = "Table";
		}

		public override void  LoadChildren(ObjectMetadata[] metadata)
		{
			this.Children = new List<TreeNode>();
			Children.Add(new ColumnsFolder(this));
			Children.Add(new IndexesFolder(this));
		}
	}
	/// <summary>
	/// Column Node
	/// </summary>
	public class ColumnNode : TreeNode
	{
		public ColumnNode(TreeNode parent, ObjectMetadata metadata) : base(parent, metadata, false)
		{
			Type = NodeTypes.Column;
			IsLeaf = true;
			ScriptingObject.Type = "Column";
		}

		public override void  LoadChildren(ObjectMetadata[] metadata)
		{
			this.Children = new List<TreeNode>();
		}
	}
	/// <summary>
	/// Index Node
	/// </summary>
	public class IndexNode : TreeNode
	{
		public IndexNode(TreeNode parent, ObjectMetadata metadata) : base(parent, metadata, true)
		{
			Type = NodeTypes.Index;
			IsLeaf = true;
			ScriptingObject.Type = "Index";
		}

		public override void  LoadChildren(ObjectMetadata[] metadata)
		{
			this.Children = new List<TreeNode>();
		}
	}
	/// <summary>
	/// View Node
	/// </summary>
	public class ViewNode : TreeNode
	{
		public ViewNode(TreeNode parent, ObjectMetadata metadata) : base(parent, metadata, false)
		{
			Type = NodeTypes.View;
			IsLeaf = false;
			ScriptingObject.Type = "View";
		}

		public override void  LoadChildren(ObjectMetadata[] metadata)
		{
			this.Children = new List<TreeNode>();
			Children.Add(new ColumnsFolder(this));
			Children.Add(new IndexesFolder(this));
		}
	}
	/// <summary>
	/// StoredProcedure Node
	/// </summary>
	public class StoredProcedureNode : TreeNode
	{
		public StoredProcedureNode(TreeNode parent, ObjectMetadata metadata) : base(parent, metadata, false)
		{
			Type = NodeTypes.StoredProcedure;
			IsLeaf = false;
			ScriptingObject.Type = "StoredProcedure";
		}

		public override void  LoadChildren(ObjectMetadata[] metadata)
		{
			this.Children = new List<TreeNode>();
			Children.Add(new ParametersFolder(this));
		}
	}
	/// <summary>
	/// Param Node
	/// </summary>
	public class ParamNode : TreeNode
	{
		public ParamNode(TreeNode parent, ObjectMetadata metadata) : base(parent, metadata, false)
		{
			Type = NodeTypes.Param;
			IsLeaf = true;
			ScriptingObject.Type = "Param";
		}

		public override void  LoadChildren(ObjectMetadata[] metadata)
		{
			this.Children = new List<TreeNode>();
		}
	}
	/// <summary>
	/// ScalarFunction Node
	/// </summary>
	public class ScalarFunctionNode : TreeNode
	{
		public ScalarFunctionNode(TreeNode parent, ObjectMetadata metadata) : base(parent, metadata, false)
		{
			Type = NodeTypes.ScalarFunction;
			IsLeaf = false;
			ScriptingObject.Type = "UserDefinedFunction";
		}

		public override void  LoadChildren(ObjectMetadata[] metadata)
		{
			this.Children = new List<TreeNode>();
			Children.Add(new ParametersFolder(this));
		}
	}
	/// <summary>
	/// TableValuedFunction Node
	/// </summary>
	public class TableValuedFunctionNode : TreeNode
	{
		public TableValuedFunctionNode(TreeNode parent, ObjectMetadata metadata) : base(parent, metadata, false)
		{
			Type = NodeTypes.TableValuedFunction;
			IsLeaf = false;
			ScriptingObject.Type = "UserDefinedFunction";
		}

		public override void  LoadChildren(ObjectMetadata[] metadata)
		{
			this.Children = new List<TreeNode>();
			Children.Add(new ParametersFolder(this));
		}
	}
	/// <summary>
	/// Shortcut Node
	/// </summary>
	public class ShortcutNode : TreeNode
	{
		public ShortcutNode(TreeNode parent, ObjectMetadata metadata) : base(parent, metadata, false)
		{
			Type = NodeTypes.Shortcut;
			IsLeaf = false;
			ScriptingObject.Type = "Shortcut";
		}

		public override void  LoadChildren(ObjectMetadata[] metadata)
		{
			this.Children = new List<TreeNode>();
			Children.Add(new ColumnsFolder(this));
		}
	}
	public class TablesFolder : FolderNode
	{
		public TablesFolder(TreeNode parent) : base(parent)
		{
			Name = "Tables";
			Type = NodeTypes.Tables;
			IsLeaf = false;
			Label = SR.SchemaHierarchy_Tables;
		}

		public override void  LoadChildren(ObjectMetadata[] metadata)
		{
			this.Children = new List<TreeNode>();
			foreach(ObjectMetadata child in metadata)
			{
				if (child.Type == "Table" && child.Parent == this.Parent.Name && child.Schema == this.SchemaName)
				{
					Children.Add(new TableNode(this, child));
				}
			}
		}
	}
	public class ColumnsFolder : FolderNode
	{
		public ColumnsFolder(TreeNode parent) : base(parent)
		{
			Name = "Columns";
			Type = NodeTypes.Columns;
			IsLeaf = false;
			Label = SR.SchemaHierarchy_Columns;
		}

		public override void  LoadChildren(ObjectMetadata[] metadata)
		{
			this.Children = new List<TreeNode>();
			foreach(ObjectMetadata child in metadata)
			{
				if (child.Type == "Column" && child.Parent == this.Parent.Name && child.Schema == this.SchemaName)
				{
					Children.Add(new ColumnNode(this, child));
				}
			}
		}
	}
	public class IndexesFolder : FolderNode
	{
		public IndexesFolder(TreeNode parent) : base(parent)
		{
			Name = "Indexes";
			Type = NodeTypes.Indexes;
			IsLeaf = false;
			Label = SR.SchemaHierarchy_Indexes;
		}

		public override void  LoadChildren(ObjectMetadata[] metadata)
		{
			this.Children = new List<TreeNode>();
			foreach(ObjectMetadata child in metadata)
			{
				if (child.Type == "Index" && child.Parent == this.Parent.Name && child.Schema == this.SchemaName)
				{
					Children.Add(new IndexNode(this, child));
				}
			}
		}
	}
	public class ViewsFolder : FolderNode
	{
		public ViewsFolder(TreeNode parent) : base(parent)
		{
			Name = "Views";
			Type = NodeTypes.Views;
			IsLeaf = false;
			Label = SR.SchemaHierarchy_Views;
		}

		public override void  LoadChildren(ObjectMetadata[] metadata)
		{
			this.Children = new List<TreeNode>();
			foreach(ObjectMetadata child in metadata)
			{
				if (child.Type == "View" && child.Parent == this.Parent.Name && child.Schema == this.SchemaName)
				{
					Children.Add(new ViewNode(this, child));
				}
			}
		}
	}
	public class StoredProceduresFolder : FolderNode
	{
		public StoredProceduresFolder(TreeNode parent) : base(parent)
		{
			Name = "StoredProcedures";
			Type = NodeTypes.StoredProcedures;
			IsLeaf = false;
			Label = SR.SchemaHierarchy_StoredProcedures;
		}

		public override void  LoadChildren(ObjectMetadata[] metadata)
		{
			this.Children = new List<TreeNode>();
			foreach(ObjectMetadata child in metadata)
			{
				if (child.Type == "StoredProcedure" && child.Parent == this.Parent.Name && child.Schema == this.SchemaName)
				{
					Children.Add(new StoredProcedureNode(this, child));
				}
			}
		}
	}
	public class ParametersFolder : FolderNode
	{
		public ParametersFolder(TreeNode parent) : base(parent)
		{
			Name = "Parameters";
			Type = NodeTypes.Parameters;
			IsLeaf = false;
			Label = SR.SchemaHierarchy_Parameters;
		}

		public override void  LoadChildren(ObjectMetadata[] metadata)
		{
			this.Children = new List<TreeNode>();
			foreach(ObjectMetadata child in metadata)
			{
				if (child.Type == "Param" && child.Parent == this.Parent.Name && child.Schema == this.SchemaName)
				{
					Children.Add(new ParamNode(this, child));
				}
			}
		}
	}
	public class FunctionsFolder : FolderNode
	{
		public FunctionsFolder(TreeNode parent) : base(parent)
		{
			Name = "Functions";
			Type = NodeTypes.Functions;
			IsLeaf = false;
			Label = SR.SchemaHierarchy_Functions;
		}

		public override void  LoadChildren(ObjectMetadata[] metadata)
		{
			this.Children = new List<TreeNode>();
			Children.Add(new ScalarFunctionsFolder(this));
			Children.Add(new TableValuedFunctionsFolder(this));
		}
	}
	public class ScalarFunctionsFolder : FolderNode
	{
		public ScalarFunctionsFolder(TreeNode parent) : base(parent)
		{
			Name = "ScalarFunctions";
			Type = NodeTypes.ScalarFunctions;
			IsLeaf = false;
			Label = SR.SchemaHierarchy_ScalarValuedFunctions;
		}

		public override void  LoadChildren(ObjectMetadata[] metadata)
		{
			this.Children = new List<TreeNode>();
			foreach(ObjectMetadata child in metadata)
			{
				if (child.Type == "ScalarFunction" && child.Parent == this.Parent.Parent.Name && child.Schema == this.SchemaName)
				{
					Children.Add(new ScalarFunctionNode(this, child));
				}
			}
		}
	}
	public class TableValuedFunctionsFolder : FolderNode
	{
		public TableValuedFunctionsFolder(TreeNode parent) : base(parent)
		{
			Name = "TableValuedFunctions";
			Type = NodeTypes.TableValuedFunctions;
			IsLeaf = false;
			Label = SR.SchemaHierarchy_TableValuedFunctions;
		}

		public override void  LoadChildren(ObjectMetadata[] metadata)
		{
			this.Children = new List<TreeNode>();
			foreach(ObjectMetadata child in metadata)
			{
				if (child.Type == "TableValuedFunction" && child.Parent == this.Parent.Parent.Name && child.Schema == this.SchemaName)
				{
					Children.Add(new TableValuedFunctionNode(this, child));
				}
			}
		}
	}
	public class ShortcutsFolder : FolderNode
	{
		public ShortcutsFolder(TreeNode parent) : base(parent)
		{
			Name = "Shortcuts";
			Type = NodeTypes.Shortcuts;
			IsLeaf = false;
			Label = SR.SchemaHierarchy_Shortcuts;
		}

		public override void  LoadChildren(ObjectMetadata[] metadata)
		{
			this.Children = new List<TreeNode>();
			foreach(ObjectMetadata child in metadata)
			{
				if (child.Type == "Shortcut" && child.Parent == this.Parent.Name && child.Schema == this.SchemaName)
				{
					Children.Add(new ShortcutNode(this, child));
				}
			}
		}
	}

	public static class ObjectExplorerModelQueries
	{
		public static Dictionary<string, string> Queries = new Dictionary<string, string>()
		{
			{ 
				"Schema", 
				@"
  SELECT
    SCHEMA_NAME AS schema_name,
    SCHEMA_NAME AS object_name,
    CATALOG_NAME COLLATE SQL_Latin1_General_CP1_CI_AS AS parent_name,
    SCHEMA_NAME AS display_name,
    'Schema' AS object_type,
    NULL AS object_sub_type
  FROM
    INFORMATION_SCHEMA.SCHEMATA
  WHERE
  SCHEMA_NAME NOT IN (
    'sys',
    'db_owner',
    'db_accessadmin',
    'db_securityadmin',
    'db_ddladmin',
    'db_backupoperator',
    'db_datareader',
    'db_datawriter',
    'db_denydatareader',
    'db_denydatawriter',
    'INFORMATION_SCHEMA',
    'guest'
  )
" 
			},
			{ 
				"Table", 
				@"
  SELECT 
      s.name AS schema_name,
      t.name AS object_name,
      s.name COLLATE SQL_Latin1_General_CP1_CI_AS AS parent_name,
      t.name AS display_name,
      'Table' AS object_type,
      NULL AS object_sub_type
  FROM 
    sys.tables t
    JOIN sys.schemas s ON t.schema_id = s.schema_id
  WHERE t.is_external = 0
  " 
			},
			{ 
				"Column", 
				@"
    SELECT
        c.TABLE_SCHEMA AS schema_name,
        c.COLUMN_NAME AS object_name,
        c.TABLE_NAME COLLATE SQL_Latin1_General_CP1_CI_AS AS parent_name,
        c.COLUMN_NAME + 
        ' (' +
        CASE 
            WHEN kcu.CONSTRAINT_NAME LIKE 'PK%' THEN 'PK, '
            ELSE ''
        END +
        CASE
            WHEN kcu2.CONSTRAINT_NAME LIKE 'FK%' THEN 'FK, '
            ELSE ''
        END + 
        c.DATA_TYPE +
        CASE  
            WHEN c.DATA_TYPE IN ('char', 'nchar', 'binary', 'varchar', 'nvarchar', 'varbinary') THEN
            CASE 
                WHEN c.CHARACTER_MAXIMUM_LENGTH = -1 THEN '(max)'
                ELSE '(' +  CAST(c.CHARACTER_MAXIMUM_LENGTH AS NVARCHAR) + ')'
            END 
            WHEN c.DATA_TYPE IN ('datetime2', 'time', 'datetimeoffset') THEN '(' +  CAST(c.DATETIME_PRECISION AS NVARCHAR) + ')'
            ELSE  ''
        END +
        -- logic for null/notnull
        CASE
            WHEN c.is_nullable = 'NO' THEN ', not null'
            ELSE ', null'
        END +
        ')' 
        AS display_name,
        'Column' AS object_type,
        CASE
            WHEN kcu.CONSTRAINT_NAME LIKE 'PK%' THEN 'PrimaryKey'
            WHEN kcu2.CONSTRAINT_NAME LIKE 'FK%' THEN 'ForeignKey'  
            ELSE NULL
        END
        AS object_sub_type
    FROM INFORMATION_SCHEMA.COLUMNS AS c
        LEFT JOIN
        INFORMATION_SCHEMA.KEY_COLUMN_USAGE AS kcu ON c.TABLE_SCHEMA = kcu.TABLE_SCHEMA AND c.TABLE_NAME = kcu.TABLE_NAME AND c.COLUMN_NAME = kcu.COLUMN_NAME AND kcu.CONSTRAINT_NAME LIKE 'PK%'
        LEFT JOIN
        INFORMATION_SCHEMA.KEY_COLUMN_USAGE AS kcu2 ON c.TABLE_SCHEMA = kcu2.TABLE_SCHEMA AND c.TABLE_NAME = kcu2.TABLE_NAME AND c.COLUMN_NAME = kcu2.COLUMN_NAME AND kcu2.CONSTRAINT_NAME LIKE 'FK%'
    " 
			},
			{ 
				"Index", 
				@"
  SELECT
    S.name AS schema_name,
    I.name AS object_name,
    O.name COLLATE SQL_Latin1_General_CP1_CI_AS AS parent_name,
    I.name + ' (' +
      CASE WHEN I.is_unique = 1 THEN 'Unique' ELSE 'Non-Unique' END + 
      ', ' +
      CASE WHEN I.index_id = 1 THEN 'Clustered' ELSE 'Non-Clustered' END +
      ')'
      AS display_name,
      'Index' AS object_type,
    CASE WHEN I.is_primary_key = 1 THEN 'PKINDEX' ELSE 'INDEX' END object_sub_type
  FROM
    sys.schemas AS S
    JOIN (        
            select object_id, name, schema_id
            FROM sys.tables
            UNION ALL
            select object_id, name, schema_id
            from sys.views
        ) AS O ON O.schema_id = S.schema_id
    JOIN sys.indexes AS I ON I.object_id = O.object_id
  Where I.name IS NOT NULL
  " 
			},
			{ 
				"View", 
				@"
  SELECT
    TABLE_SCHEMA AS schema_name,
    TABLE_NAME AS object_name,
    TABLE_SCHEMA COLLATE SQL_Latin1_General_CP1_CI_AS AS parent_name,
    TABLE_NAME AS display_name,
    'View' AS object_type,
    NULL AS object_sub_type
  FROM
    INFORMATION_SCHEMA.TABLES
  WHERE
    TABLE_TYPE = 'VIEW'
  " 
			},
			{ 
				"StoredProcedure", 
				@"
  SELECT
    SPECIFIC_SCHEMA AS schema_name,
    SPECIFIC_NAME AS object_name,
    SPECIFIC_SCHEMA COLLATE SQL_Latin1_General_CP1_CI_AS AS parent_name,
    SPECIFIC_NAME AS display_name,
    'StoredProcedure' AS object_type,
    NULL AS object_sub_type
  FROM
    INFORMATION_SCHEMA.ROUTINES
  WHERE
    ROUTINE_TYPE = 'PROCEDURE'
  " 
			},
			{ 
				"Param", 
				@"
    SELECT
        S.name AS schema_name,
        P.name AS object_name,
        O.name COLLATE SQL_Latin1_General_CP1_CI_AS AS parent_name,
        P.name +  ' (' +  TP.name + ', ' +
        CASE WHEN P.is_output = 1 THEN 'Output' ELSE 'Input' END + ', ' +
        CASE WHEN P.has_default_value = 1 THEN 'Default' ELSE 'No default' END + ')'
        AS display_name,
        'Param' AS object_type,
        CASE WHEN P.is_output = 1 THEN 'OutputParameter' ELSE 'InputParameter' END AS object_sub_type
    FROM
        sys.parameters AS P
        JOIN sys.types AS TP ON P.user_type_id = TP.user_type_id
        JOIN sys.objects AS O ON O.object_id = P.object_id
        JOIN sys.schemas AS S ON O.schema_id = S.schema_id
    WHERE P.name != NULL OR P.name != ''
" 
			},
			{ 
				"ScalarFunction", 
				@"
  SELECT
      S.name AS schema_name,
      P.name AS object_name,
      S.name COLLATE SQL_Latin1_General_CP1_CI_AS AS parent_name,
      P.name AS display_name,
      'ScalarFunction' AS object_type,
      NULL AS object_sub_type
  FROM
      sys.schemas AS S
      JOIN sys.objects AS P ON S.schema_id = P.schema_id
  WHERE
      P.type = 'FN'
  " 
			},
			{ 
				"TableValuedFunction", 
				@"
  SELECT
      S.name AS schema_name,
      P.name AS object_name,
      S.name COLLATE SQL_Latin1_General_CP1_CI_AS AS parent_name,
      P.name AS display_name,
      'TableValuedFunction' AS object_type,
      NULL AS object_sub_type
  FROM
      sys.schemas AS S
      JOIN sys.objects AS P ON S.schema_id = P.schema_id
  WHERE
      P.type = 'IF' OR P.type = 'TF'
  " 
			},
			{ 
				"Shortcut", 
				@"
  SELECT 
      s.name AS schema_name,
      t.name AS object_name,
      s.name COLLATE SQL_Latin1_General_CP1_CI_AS AS parent_name,
      t.name AS display_name,
      'Shortcut' AS object_type,
      NULL AS object_sub_type
  FROM 
    sys.tables t
    JOIN sys.schemas s ON t.schema_id = s.schema_id
  WHERE t.is_external = 1
  " 
			},
		};
	}

	public enum NodeTypes
	{
		Database,
		Schema,
		Table,
		Column,
		Index,
		View,
		StoredProcedure,
		Param,
		ScalarFunction,
		TableValuedFunction,
		Shortcut,
		Tables,
		Columns,
		Indexes,
		Views,
		StoredProcedures,
		Parameters,
		Functions,
		ScalarFunctions,
		TableValuedFunctions,
		Shortcuts,
		Folder,
	}
}
