﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34011
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ThiVeMyThuat
{
	using System.Data.Linq;
	using System.Data.Linq.Mapping;
	using System.Data;
	using System.Collections.Generic;
	using System.Reflection;
	using System.Linq;
	using System.Linq.Expressions;
	using System.ComponentModel;
	using System;
	
	
	[global::System.Data.Linq.Mapping.DatabaseAttribute(Name="XDA")]
	public partial class dbVeMTDataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Extensibility Method Definitions
    partial void OnCreated();
    partial void Insertvemt(vemt instance);
    partial void Updatevemt(vemt instance);
    partial void Deletevemt(vemt instance);
    partial void Insertnhanvien(nhanvien instance);
    partial void Updatenhanvien(nhanvien instance);
    partial void Deletenhanvien(nhanvien instance);
    #endregion
		
		public dbVeMTDataContext() : 
				base(global::ThiVeMyThuat.Properties.Settings.Default.XDAConnectionString3, mappingSource)
		{
			OnCreated();
		}
		
		public dbVeMTDataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public dbVeMTDataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public dbVeMTDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public dbVeMTDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public System.Data.Linq.Table<vemt> vemts
		{
			get
			{
				return this.GetTable<vemt>();
			}
		}
		
		public System.Data.Linq.Table<nhanvien> nhanviens
		{
			get
			{
				return this.GetTable<nhanvien>();
			}
		}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="dbo.layTen", IsComposable=true)]
		public string layTen([global::System.Data.Linq.Mapping.ParameterAttribute(Name="Hoten", DbType="NVarChar(25)")] string hoten)
		{
			return ((string)(this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), hoten).ReturnValue));
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.vemt")]
	public partial class vemt : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private string _sohs;
		
		private string _hoten;
		
		private System.Nullable<bool> _phai;
		
		private string _gt;
		
		private System.Nullable<System.DateTime> _ngaysinh;
		
		private System.Nullable<double> _namtn;
		
		private string _sobaodanh;
		
		private System.Nullable<double> _phongthi;
		
		private string _phone;
		
		private string _ghichu;
		
		private System.Nullable<double> _diem;
		
		private string _hktt;
		
		private string _huyenhktt;
		
		private string _noisinh;
		
		private string _email;
		
		private string _cmnd;
		
		private System.Nullable<System.DateTime> _ngcapcmt;
		
		private string _noicap;
		
		private System.Nullable<bool> _lephi;
		
		private System.Nullable<double> _tui;
		
		private System.Nullable<double> _phach;
		
		private System.Nullable<int> _stt;
		
		private System.Nullable<int> _stttui;
		
		private string _phonecodinh;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnsohsChanging(string value);
    partial void OnsohsChanged();
    partial void OnhotenChanging(string value);
    partial void OnhotenChanged();
    partial void OnphaiChanging(System.Nullable<bool> value);
    partial void OnphaiChanged();
    partial void OngtChanging(string value);
    partial void OngtChanged();
    partial void OnngaysinhChanging(System.Nullable<System.DateTime> value);
    partial void OnngaysinhChanged();
    partial void OnnamtnChanging(System.Nullable<double> value);
    partial void OnnamtnChanged();
    partial void OnsobaodanhChanging(string value);
    partial void OnsobaodanhChanged();
    partial void OnphongthiChanging(System.Nullable<double> value);
    partial void OnphongthiChanged();
    partial void OnphoneChanging(string value);
    partial void OnphoneChanged();
    partial void OnghichuChanging(string value);
    partial void OnghichuChanged();
    partial void OndiemChanging(System.Nullable<double> value);
    partial void OndiemChanged();
    partial void OnhkttChanging(string value);
    partial void OnhkttChanged();
    partial void OnhuyenhkttChanging(string value);
    partial void OnhuyenhkttChanged();
    partial void OnnoisinhChanging(string value);
    partial void OnnoisinhChanged();
    partial void OnemailChanging(string value);
    partial void OnemailChanged();
    partial void OncmndChanging(string value);
    partial void OncmndChanged();
    partial void OnngcapcmtChanging(System.Nullable<System.DateTime> value);
    partial void OnngcapcmtChanged();
    partial void OnnoicapChanging(string value);
    partial void OnnoicapChanged();
    partial void OnlephiChanging(System.Nullable<bool> value);
    partial void OnlephiChanged();
    partial void OntuiChanging(System.Nullable<double> value);
    partial void OntuiChanged();
    partial void OnphachChanging(System.Nullable<double> value);
    partial void OnphachChanged();
    partial void OnsttChanging(System.Nullable<int> value);
    partial void OnsttChanged();
    partial void OnstttuiChanging(System.Nullable<int> value);
    partial void OnstttuiChanged();
    partial void OnphonecodinhChanging(string value);
    partial void OnphonecodinhChanged();
    #endregion
		
		public vemt()
		{
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_sohs", DbType="NVarChar(50) NOT NULL", CanBeNull=false, IsPrimaryKey=true)]
		public string sohs
		{
			get
			{
				return this._sohs;
			}
			set
			{
				if ((this._sohs != value))
				{
					this.OnsohsChanging(value);
					this.SendPropertyChanging();
					this._sohs = value;
					this.SendPropertyChanged("sohs");
					this.OnsohsChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_hoten", DbType="NVarChar(255)")]
		public string hoten
		{
			get
			{
				return this._hoten;
			}
			set
			{
				if ((this._hoten != value))
				{
					this.OnhotenChanging(value);
					this.SendPropertyChanging();
					this._hoten = value;
					this.SendPropertyChanged("hoten");
					this.OnhotenChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_phai", DbType="Bit")]
		public System.Nullable<bool> phai
		{
			get
			{
				return this._phai;
			}
			set
			{
				if ((this._phai != value))
				{
					this.OnphaiChanging(value);
					this.SendPropertyChanging();
					this._phai = value;
					this.SendPropertyChanged("phai");
					this.OnphaiChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_gt", DbType="NVarChar(50)")]
		public string gt
		{
			get
			{
				return this._gt;
			}
			set
			{
				if ((this._gt != value))
				{
					this.OngtChanging(value);
					this.SendPropertyChanging();
					this._gt = value;
					this.SendPropertyChanged("gt");
					this.OngtChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ngaysinh", DbType="DateTime")]
		public System.Nullable<System.DateTime> ngaysinh
		{
			get
			{
				return this._ngaysinh;
			}
			set
			{
				if ((this._ngaysinh != value))
				{
					this.OnngaysinhChanging(value);
					this.SendPropertyChanging();
					this._ngaysinh = value;
					this.SendPropertyChanged("ngaysinh");
					this.OnngaysinhChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_namtn", DbType="Float")]
		public System.Nullable<double> namtn
		{
			get
			{
				return this._namtn;
			}
			set
			{
				if ((this._namtn != value))
				{
					this.OnnamtnChanging(value);
					this.SendPropertyChanging();
					this._namtn = value;
					this.SendPropertyChanged("namtn");
					this.OnnamtnChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_sobaodanh", DbType="NVarChar(255)")]
		public string sobaodanh
		{
			get
			{
				return this._sobaodanh;
			}
			set
			{
				if ((this._sobaodanh != value))
				{
					this.OnsobaodanhChanging(value);
					this.SendPropertyChanging();
					this._sobaodanh = value;
					this.SendPropertyChanged("sobaodanh");
					this.OnsobaodanhChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_phongthi", DbType="Float")]
		public System.Nullable<double> phongthi
		{
			get
			{
				return this._phongthi;
			}
			set
			{
				if ((this._phongthi != value))
				{
					this.OnphongthiChanging(value);
					this.SendPropertyChanging();
					this._phongthi = value;
					this.SendPropertyChanged("phongthi");
					this.OnphongthiChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_phone", DbType="NVarChar(20)")]
		public string phone
		{
			get
			{
				return this._phone;
			}
			set
			{
				if ((this._phone != value))
				{
					this.OnphoneChanging(value);
					this.SendPropertyChanging();
					this._phone = value;
					this.SendPropertyChanged("phone");
					this.OnphoneChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ghichu", DbType="NVarChar(255)")]
		public string ghichu
		{
			get
			{
				return this._ghichu;
			}
			set
			{
				if ((this._ghichu != value))
				{
					this.OnghichuChanging(value);
					this.SendPropertyChanging();
					this._ghichu = value;
					this.SendPropertyChanged("ghichu");
					this.OnghichuChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_diem", DbType="Float")]
		public System.Nullable<double> diem
		{
			get
			{
				return this._diem;
			}
			set
			{
				if ((this._diem != value))
				{
					this.OndiemChanging(value);
					this.SendPropertyChanging();
					this._diem = value;
					this.SendPropertyChanged("diem");
					this.OndiemChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_hktt", DbType="NVarChar(255)")]
		public string hktt
		{
			get
			{
				return this._hktt;
			}
			set
			{
				if ((this._hktt != value))
				{
					this.OnhkttChanging(value);
					this.SendPropertyChanging();
					this._hktt = value;
					this.SendPropertyChanged("hktt");
					this.OnhkttChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_huyenhktt", DbType="NVarChar(255)")]
		public string huyenhktt
		{
			get
			{
				return this._huyenhktt;
			}
			set
			{
				if ((this._huyenhktt != value))
				{
					this.OnhuyenhkttChanging(value);
					this.SendPropertyChanging();
					this._huyenhktt = value;
					this.SendPropertyChanged("huyenhktt");
					this.OnhuyenhkttChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_noisinh", DbType="NVarChar(255)")]
		public string noisinh
		{
			get
			{
				return this._noisinh;
			}
			set
			{
				if ((this._noisinh != value))
				{
					this.OnnoisinhChanging(value);
					this.SendPropertyChanging();
					this._noisinh = value;
					this.SendPropertyChanged("noisinh");
					this.OnnoisinhChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_email", DbType="NVarChar(255)")]
		public string email
		{
			get
			{
				return this._email;
			}
			set
			{
				if ((this._email != value))
				{
					this.OnemailChanging(value);
					this.SendPropertyChanging();
					this._email = value;
					this.SendPropertyChanged("email");
					this.OnemailChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_cmnd", DbType="VarChar(50)")]
		public string cmnd
		{
			get
			{
				return this._cmnd;
			}
			set
			{
				if ((this._cmnd != value))
				{
					this.OncmndChanging(value);
					this.SendPropertyChanging();
					this._cmnd = value;
					this.SendPropertyChanged("cmnd");
					this.OncmndChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ngcapcmt", DbType="DateTime")]
		public System.Nullable<System.DateTime> ngcapcmt
		{
			get
			{
				return this._ngcapcmt;
			}
			set
			{
				if ((this._ngcapcmt != value))
				{
					this.OnngcapcmtChanging(value);
					this.SendPropertyChanging();
					this._ngcapcmt = value;
					this.SendPropertyChanged("ngcapcmt");
					this.OnngcapcmtChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_noicap", DbType="NVarChar(255)")]
		public string noicap
		{
			get
			{
				return this._noicap;
			}
			set
			{
				if ((this._noicap != value))
				{
					this.OnnoicapChanging(value);
					this.SendPropertyChanging();
					this._noicap = value;
					this.SendPropertyChanged("noicap");
					this.OnnoicapChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_lephi", DbType="Bit")]
		public System.Nullable<bool> lephi
		{
			get
			{
				return this._lephi;
			}
			set
			{
				if ((this._lephi != value))
				{
					this.OnlephiChanging(value);
					this.SendPropertyChanging();
					this._lephi = value;
					this.SendPropertyChanged("lephi");
					this.OnlephiChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_tui", DbType="Float")]
		public System.Nullable<double> tui
		{
			get
			{
				return this._tui;
			}
			set
			{
				if ((this._tui != value))
				{
					this.OntuiChanging(value);
					this.SendPropertyChanging();
					this._tui = value;
					this.SendPropertyChanged("tui");
					this.OntuiChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_phach", DbType="Float")]
		public System.Nullable<double> phach
		{
			get
			{
				return this._phach;
			}
			set
			{
				if ((this._phach != value))
				{
					this.OnphachChanging(value);
					this.SendPropertyChanging();
					this._phach = value;
					this.SendPropertyChanged("phach");
					this.OnphachChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_stt", DbType="Int")]
		public System.Nullable<int> stt
		{
			get
			{
				return this._stt;
			}
			set
			{
				if ((this._stt != value))
				{
					this.OnsttChanging(value);
					this.SendPropertyChanging();
					this._stt = value;
					this.SendPropertyChanged("stt");
					this.OnsttChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_stttui", DbType="Int")]
		public System.Nullable<int> stttui
		{
			get
			{
				return this._stttui;
			}
			set
			{
				if ((this._stttui != value))
				{
					this.OnstttuiChanging(value);
					this.SendPropertyChanging();
					this._stttui = value;
					this.SendPropertyChanged("stttui");
					this.OnstttuiChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_phonecodinh", DbType="NVarChar(20)")]
		public string phonecodinh
		{
			get
			{
				return this._phonecodinh;
			}
			set
			{
				if ((this._phonecodinh != value))
				{
					this.OnphonecodinhChanging(value);
					this.SendPropertyChanging();
					this._phonecodinh = value;
					this.SendPropertyChanged("phonecodinh");
					this.OnphonecodinhChanged();
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.nhanvien")]
	public partial class nhanvien : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private string _username;
		
		private string _pass;
		
		private string _tennguoidung;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnusernameChanging(string value);
    partial void OnusernameChanged();
    partial void OnpassChanging(string value);
    partial void OnpassChanged();
    partial void OntennguoidungChanging(string value);
    partial void OntennguoidungChanged();
    #endregion
		
		public nhanvien()
		{
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_username", DbType="NVarChar(25) NOT NULL", CanBeNull=false, IsPrimaryKey=true)]
		public string username
		{
			get
			{
				return this._username;
			}
			set
			{
				if ((this._username != value))
				{
					this.OnusernameChanging(value);
					this.SendPropertyChanging();
					this._username = value;
					this.SendPropertyChanged("username");
					this.OnusernameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_pass", DbType="NVarChar(50)")]
		public string pass
		{
			get
			{
				return this._pass;
			}
			set
			{
				if ((this._pass != value))
				{
					this.OnpassChanging(value);
					this.SendPropertyChanging();
					this._pass = value;
					this.SendPropertyChanged("pass");
					this.OnpassChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_tennguoidung", DbType="NChar(50)")]
		public string tennguoidung
		{
			get
			{
				return this._tennguoidung;
			}
			set
			{
				if ((this._tennguoidung != value))
				{
					this.OntennguoidungChanging(value);
					this.SendPropertyChanging();
					this._tennguoidung = value;
					this.SendPropertyChanged("tennguoidung");
					this.OntennguoidungChanged();
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
}
#pragma warning restore 1591
