using System.Runtime.InteropServices;

namespace Rime.Api;

/// <summary>
/// RimeApi is for rime v1.0+
/// </summary>
[StructLayout(LayoutKind.Sequential)]
unsafe public struct RimeApi{
	public int data_size;

	#region  setup
	/// <summary>
	/// Call this function before accessing any other API functions.
	/// </summary>
	public delegate* unmanaged[Cdecl]<
		RimeTraits* // traits
		,void
	> setup;


  /*! Set up the notification callbacks
   *  Receive notifications
   *  - on loading schema:
   *    + message_type="schema", message_value="luna_pinyin/Luna Pinyin"
   *  - on changing mode:
   *    + message_type="option", message_value="ascii_mode"
   *    + message_type="option", message_value="!ascii_mode"
   *  - on deployment:
   *    + session_id = 0, message_type="deploy", message_value="start"
   *    + session_id = 0, message_type="deploy", message_value="success"
   *    + session_id = 0, message_type="deploy", message_value="failure"
   *
   *  handler will be called with context_object as the first parameter
   *  every time an event occurs in librime, until RimeFinalize() is called.
   *  when handler is NULL, notification is disabled.
   */
	public delegate* unmanaged[Cdecl]<
		RimeNotificationHandler // handler
		, void* // context_object
		,void
	> set_notification_handler;

	#endregion setup

	#region entry ans exit
	public delegate* unmanaged[Cdecl]<
		RimeTraits* // traits
		,void
	> initialize;
	public delegate* unmanaged[Cdecl]<
		void
	> finalize;
	public delegate* unmanaged[Cdecl]<
		Bool // full_check
		,Bool
	> start_maintenance;

	public delegate* unmanaged[Cdecl]<
		Bool
	> is_maintenance_mode;
	public delegate* unmanaged[Cdecl]<
		void
	> join_maintenance_thread;
	#endregion entry ans exit


	#region deployment
	public delegate* unmanaged[Cdecl]<
		RimeTraits* // traits
		,void
	> deployer_initialize;
	public delegate* unmanaged[Cdecl]<
		Bool
	> prebuild;
	public delegate* unmanaged[Cdecl]<
		Bool
	> deploy;
	public delegate* unmanaged[Cdecl]<
		byte* // schema_file
		,Bool
	> deploy_schema;
	public delegate* unmanaged[Cdecl]<
		byte* // file_name
		, byte* // version_key
		,Bool
	> deploy_config_file;
	public delegate* unmanaged[Cdecl]<
		Bool
	> sync_user_data;
	#endregion deployment

	#region session management
	public delegate* unmanaged[Cdecl]<
		RimeSessionId
	> create_session;
	public delegate* unmanaged[Cdecl]<
		RimeSessionId // session_id
		,Bool
	> find_session;
	public delegate* unmanaged[Cdecl]<
		RimeSessionId // session_id
		,Bool
	> destroy_session;
	public delegate* unmanaged[Cdecl]<
		void
	> cleanup_stale_sessions;
	public delegate* unmanaged[Cdecl]<
		void
	> cleanup_all_sessions;
	#endregion session management

	#region input
	public delegate* unmanaged[Cdecl]<
		RimeSessionId // session_id
		, int // keycode
		, int // mask
		,Bool
	> process_key;
	public delegate* unmanaged[Cdecl]<
		RimeSessionId // session_id
		,Bool
	> commit_composition;
	public delegate* unmanaged[Cdecl]<
		RimeSessionId // session_id
		,void
	> clear_composition;
	#endregion input

	#region output
	public delegate* unmanaged[Cdecl]<
		RimeSessionId // session_id
		, RimeCommit* // commit
		,Bool
	> get_commit;
	public delegate* unmanaged[Cdecl]<
		RimeCommit* // commit
		,Bool
	> free_commit;
	public delegate* unmanaged[Cdecl]<
		RimeSessionId // session_id
		, RimeContext* // context
		,Bool
	> get_context;
	public delegate* unmanaged[Cdecl]<
		RimeContext* // ctx
		,Bool
	> free_context;
	public delegate* unmanaged[Cdecl]<
		RimeSessionId // session_id
		, RimeStatus* // status
		,Bool
	> get_status;
	public delegate* unmanaged[Cdecl]<
		RimeStatus* // status
		,Bool
	> free_status;
	#endregion output


	#region runtime options
	public delegate* unmanaged[Cdecl]<
		RimeSessionId // session_id
		, byte* // option
		, Bool // value
		,void
	> set_option;
	public delegate* unmanaged[Cdecl]<
		RimeSessionId // session_id
		, byte* // option
		,Bool
	> get_option;
	public delegate* unmanaged[Cdecl]<
		RimeSessionId // session_id
		, byte* // prop
		, byte* // value
		,void
	> set_property;
	public delegate* unmanaged[Cdecl]<
		RimeSessionId // session_id
		, byte* // prop
		, byte* // value
		, size_t // buffer_size
		,Bool
	> get_property;
	public delegate* unmanaged[Cdecl]<
		RimeSchemaList* // schema_list
		,Bool
	> get_schema_list;
	public delegate* unmanaged[Cdecl]<
		RimeSchemaList* // schema_list
		,void
	> free_schema_list;
	public delegate* unmanaged[Cdecl]<
		RimeSessionId // session_id
		, byte* // schema_id
		, size_t // buffer_size
		,Bool
	> get_current_schema;
	public delegate* unmanaged[Cdecl]<
		RimeSessionId // session_id
		, byte* // schema_id
		,Bool
	> select_schema;
	#endregion runtime options



	#region configuration
	public delegate* unmanaged[Cdecl]<
		byte* // schema_id
		, RimeConfig* // config
		,Bool
	> schema_open;
	public delegate* unmanaged[Cdecl]<
		byte* // config_id
		, RimeConfig* // config
		,Bool
	> config_open;
	public delegate* unmanaged[Cdecl]<
		RimeConfig* // config
		,Bool
	> config_close;
	public delegate* unmanaged[Cdecl]<
		RimeConfig* // config
		, byte* // key
		, Bool* // value
		,Bool
	> config_get_bool;
	public delegate* unmanaged[Cdecl]<
		RimeConfig* // config
		, byte* // key
		, int* // value
		,Bool
	> config_get_int;
	public delegate* unmanaged[Cdecl]<
		RimeConfig* // config
		, byte* // key
		, double* // value
		,Bool
	> config_get_double;
	public delegate* unmanaged[Cdecl]<
		RimeConfig* // config
		, byte* // key
		, byte* // value
		, size_t // buffer_size
		,Bool
	> config_get_string;
	public delegate* unmanaged[Cdecl]<
		RimeConfig* // config
		, byte* // key
		,byte*
	> config_get_cstring;
	public delegate* unmanaged[Cdecl]<
		RimeConfig* // config
		, byte* // signer
		,Bool
	> config_update_signature;
	public delegate* unmanaged[Cdecl]<
		RimeConfigIterator* // iterator
		, RimeConfig* // config
		, byte* // key
		,Bool
	> config_begin_map;
	public delegate* unmanaged[Cdecl]<
		RimeConfigIterator* // iterator
		,Bool
	> config_next;
	public delegate* unmanaged[Cdecl]<
		RimeConfigIterator* // iterator
		,void
	> config_end;
	#endregion configuration


	#region testing
	public delegate* unmanaged[Cdecl]<
		RimeSessionId // session_id
		, byte* // key_sequence
		,Bool
	> simulate_key_sequence;
	#endregion testing


	#region module
	public delegate* unmanaged[Cdecl]<
		RimeModule* // module
		,Bool
	> register_module;
	public delegate* unmanaged[Cdecl]<
		byte* // module_name
		,RimeModule*
	> find_module;
	public delegate* unmanaged[Cdecl]<
		byte* // task_name
		,Bool
	> run_task;
	public delegate* unmanaged[Cdecl]<
		byte*
	> get_shared_data_dir;
	public delegate* unmanaged[Cdecl]<
		byte*
	> get_user_data_dir;
	public delegate* unmanaged[Cdecl]<
		byte*
	> get_sync_dir;
	public delegate* unmanaged[Cdecl]<
		byte*
	> get_user_id;
	public delegate* unmanaged[Cdecl]<
		byte* // dir
		, size_t // buffer_size
		,void
	> get_user_data_sync_dir;

	/// <summary>
	/// initialize an empty config object
	/// should call config_close() to free the object
	/// </summary>
	public delegate* unmanaged[Cdecl]<
		RimeConfig* // config
		,Bool
	> config_init;

	/// <summary>
	/// deserialize config from a yaml string
	/// </summary>
	public delegate* unmanaged[Cdecl]<
		RimeConfig* // config
		, byte* // yaml
		,Bool
	> config_load_string;
	#endregion module


	#region configuration: setters
	public delegate* unmanaged[Cdecl]<
		RimeConfig* // config
		, byte* // key
		, Bool // value
		,Bool
	> config_set_bool;
	public delegate* unmanaged[Cdecl]<
		RimeConfig* // config
		, byte* // key
		, int // value
		,Bool
	> config_set_int;
	public delegate* unmanaged[Cdecl]<
		RimeConfig* // config
		, byte* // key
		, double // value
		,Bool
	> config_set_double;
	public delegate* unmanaged[Cdecl]<
		RimeConfig* // config
		, byte* // key
		, byte* // value
		,Bool
	> config_set_string;

	#endregion configuration: setters


	#region configuration: manipulating complex structures
	public delegate* unmanaged[Cdecl]<
		RimeConfig* // config
		, byte* // key
		, RimeConfig* // value
		,Bool
	> config_get_item;
	public delegate* unmanaged[Cdecl]<
		RimeConfig* // config
		, byte* // key
		, RimeConfig* // value
		,Bool
	> config_set_item;
	public delegate* unmanaged[Cdecl]<
		RimeConfig* // config
		, byte* // key
		,Bool
	> config_clear;
	public delegate* unmanaged[Cdecl]<
		RimeConfig* // config
		, byte* // key
		,Bool
	> config_create_list;
	public delegate* unmanaged[Cdecl]<
		RimeConfig* // config
		, byte* // key
		,Bool
	> config_create_map;
	public delegate* unmanaged[Cdecl]<
		RimeConfig* // config
		, byte* // key
		,size_t
	> config_list_size;
	public delegate* unmanaged[Cdecl]<
		RimeConfigIterator* // iterator
		, RimeConfig* // config
		, byte* // key
		,Bool
	> config_begin_list;
	#endregion configuration: manipulating complex structures

  //! get raw input
  /*!
   *  NULL is returned if session does not exist.
   *  the returned pointer to input string will become invalid upon editing.
   */
	public delegate* unmanaged[Cdecl]<
		RimeSessionId // session_id
		,byte*
	> get_input;

	/// <summary>
	/// caret position in terms of raw input
	/// </summary>
	public delegate* unmanaged[Cdecl]<
		RimeSessionId // session_id
		,size_t
	> get_caret_pos;

	/// <summary>
	/// select a candidate at the given index in candidate list.
	/// </summary>
	public delegate* unmanaged[Cdecl]<
		RimeSessionId // session_id
		, size_t // index
		,Bool
	> select_candidate;
	/// <summary>
	/// get the version of librime
	/// </summary>
	public delegate* unmanaged[Cdecl]<
		byte*
	> get_version;

	/// <summary>
	/// set caret position in terms of raw input
	/// </summary>
	public delegate* unmanaged[Cdecl]<
		RimeSessionId // session_id
		, size_t // caret_pos
		,void
	> set_caret_pos;
	/// <summary>
	/// select a candidate from current page.
	/// </summary>
	public delegate* unmanaged[Cdecl]<
		RimeSessionId // session_id
		, size_t // index
		,Bool
	> select_candidate_on_current_page;
	/// <summary>
	/// access candidate list.
	/// </summary>
	public delegate* unmanaged[Cdecl]<
		RimeSessionId // session_id
		, RimeCandidateListIterator* // iterator
		,Bool
	> candidate_list_begin;
	public delegate* unmanaged[Cdecl]<
		RimeCandidateListIterator* // iterator
		,Bool
	> candidate_list_next;
	public delegate* unmanaged[Cdecl]<
		RimeCandidateListIterator* // iterator
		,void
	> candidate_list_end;

	/// <summary>
	//! access config files in user data directory, eg. user.yaml and
	//! installation.yaml
	/// </summary>
	public delegate* unmanaged[Cdecl]<
		byte* // config_id
		, RimeConfig* // config
		,Bool
	> user_config_open;
	public delegate* unmanaged[Cdecl]<
		RimeSessionId // session_id
		, RimeCandidateListIterator* // iterator
		, int // index
		,Bool
	> candidate_list_from_index;

	/// <summary>
	/// prebuilt data directory.
	/// </summary>
	public delegate* unmanaged[Cdecl]<
		byte*
	> get_prebuilt_data_dir;
	/// <summary>
	/// staging directory, stores data files deployed to a Rime client.
	/// </summary>
	public delegate* unmanaged[Cdecl]<
		byte*
	> get_staging_dir;

	/// <summary>
	/// 小狼毫0.15.0ʃ用ʹrime.dll中 此潙空指針
	/// </summary>
	[Obsolete("Deprecated: for capnproto API, use \"proto\" module from librime-proto")]
	/// <summary>
	/// 小狼毫0.15.0ʃ用ʹrime.dll中 此潙空指針
	/// </summary>
	public delegate* unmanaged[Cdecl]<
		RimeSessionId // session_id
		, void* // commit_builder
		,void
	> commit_proto;
	[Obsolete("Deprecated: for capnproto API, use \"proto\" module from librime-proto")]
	/// <summary>
	/// 小狼毫0.15.0ʃ用ʹrime.dll中 此潙空指針
	/// </summary>
	public delegate* unmanaged[Cdecl]<
		RimeSessionId // session_id
		, void* // context_builder
		,void
	> context_proto;
	[Obsolete("Deprecated: for capnproto API, use \"proto\" module from librime-proto")]
	public delegate* unmanaged[Cdecl]<
		RimeSessionId // session_id
		, void* // status_builder
		,void
	> status_proto;

	/// <summary>
	/// delete a candidate at the given index in candidate list.
	/// </summary>
	public delegate* unmanaged[Cdecl]<
		RimeSessionId // session_id
		, size_t // index
		,Bool
	> delete_candidate;
	/// <summary>
	/// delete a candidate from current page.
	/// </summary>
	public delegate* unmanaged[Cdecl]<
		RimeSessionId // session_id
		, size_t // index
		,Bool
	> delete_candidate_on_current_page;

	public delegate* unmanaged[Cdecl]<
		RimeSessionId // session_id
		, byte* // option_name
		, Bool // state
		, Bool // abbreviated
		,RimeStringSlice
	> get_state_label_abbreviated;
	public delegate* unmanaged[Cdecl]<
		RimeSessionId // session_id
		, byte* // input
		,Bool
	> set_input;

}
