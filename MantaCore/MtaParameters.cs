﻿using System.Collections.Generic;
using System.IO;

namespace MantaMTA.Core
{
	public class MtaParameters
	{
		/// <summary>
		/// Name of the MTA. Used in welcome banner to identify product.
		/// </summary>
		public const string MTA_NAME = "BatHawk";

		/// <summary>
		/// New line as should be used in emails.
		/// </summary>
		internal const string NewLine = "\r\n";

		/// <summary>
		/// Gets the ports that the SMTP server should listen for client connections on.
		/// This will almost always be 25 & 587.
		/// </summary>
		public static int[] ServerListeningPorts
		{
			get 
			{
				if (_ServerListeningPorts == null)
					_ServerListeningPorts = DAL.CfgPara.GetServerListenPorts();
				return _ServerListeningPorts;
			}
		}
		private static int[] _ServerListeningPorts { get; set; }

		/// <summary>
		/// Drop folder, for incoming messages.
		/// This should be in config.
		/// </summary>
		internal static string MTA_DROPFOLDER
		{
			get
			{
				if(string.IsNullOrEmpty(_MtaDropFolder))
				{
					_MtaDropFolder = DAL.CfgPara.GetDropFolder();
					Directory.CreateDirectory(_MtaDropFolder);
				}

				return _MtaDropFolder;
			}
		}
		private static string _MtaDropFolder { get; set; }

		/// <summary>
		/// Queue folder, for messages to be sent.
		/// </summary>
		internal static string MTA_QUEUEFOLDER
		{
			get
			{
				if (string.IsNullOrEmpty(_MtaQueueFolder))
				{
					_MtaQueueFolder = DAL.CfgPara.GetQueueFolder();
					Directory.CreateDirectory(_MtaQueueFolder);
				}

				return _MtaQueueFolder;
			}
		}
		private static string _MtaQueueFolder { get; set; }

		/// <summary>
		/// Log foler, where SMTP Transaction logs will go.
		/// This should be in config.
		/// </summary>
		internal static string MTA_LOGFOLDER
		{
			get
			{
				if (string.IsNullOrEmpty(_MtaDropFolder))
				{
					_MtaLogFolder = DAL.CfgPara.GetLogFolder();
					Directory.CreateDirectory(_MtaLogFolder);
				}

				return _MtaLogFolder;
			}
		}
		private static string _MtaLogFolder { get; set; }

		/// <summary>
		/// List of domains to accept messages for drop folder.
		/// All domains are toLowered!
		/// </summary>
		internal static string[] LocalDomains
		{
			get
			{
				if (_LocalDomains == null)
					_LocalDomains = DAL.CfgLocalDomains.GetLocalDomainsArray();
				return _LocalDomains;
			}
		}
		private static string[] _LocalDomains { get; set; }

		/// <summary>
		/// List of IP addresses to allow relaying for.
		/// </summary>
		internal static string[] IPsToAllowRelaying
		{
			get
			{
				if (_IPsToAllowRelaying == null)
					_IPsToAllowRelaying = DAL.CfgRelayingPermittedIP.GetRelayingPermittedIPAddresses();
				return _IPsToAllowRelaying;
			}
		}
		private static string[] _IPsToAllowRelaying { get; set; }

		/// <summary>
		/// The time in minutes between send retries.
		/// </summary>
		internal static int MTA_RETRY_INTERVAL 
		{
			get
			{
				if(_MTA_RETRY_INTERVAL == -1)
					_MTA_RETRY_INTERVAL = DAL.CfgPara.GetRetryIntervalMinutes();

				return _MTA_RETRY_INTERVAL;
			}
		}
		private static int _MTA_RETRY_INTERVAL = -1;

		/// <summary>
		/// The maximum time in minutes that a message can be in the queue.
		/// </summary>
		internal static int MTA_MAX_TIME_IN_QUEUE
		{
			get
			{
				if (_MTA_MAX_TIME_IN_QUEUE == -1)
					_MTA_MAX_TIME_IN_QUEUE = DAL.CfgPara.GetMaxTimeInQueueMinutes();

				return _MTA_MAX_TIME_IN_QUEUE;
			}
		}
		private static int _MTA_MAX_TIME_IN_QUEUE = -1;

		internal static class Client
		{
			/// <summary>
			/// Port for SMTP connections by the client to remote servers when sending
			/// messages. This will likely only every change when developing/debugging.
			/// </summary>
			public const int SMTP_PORT = 25;

			/// <summary>
			/// The time in seconds after which an active but idle connection should be
			/// considered timed out.
			/// </summary>
			public static int ConnectionIdleTimeoutInterval
			{
				get
				{
					if (_ConnectionIdleTimeoutInterval == -1)
						_ConnectionIdleTimeoutInterval = DAL.CfgPara.GetClientIdleTimeout();

					return _ConnectionIdleTimeoutInterval;
				}
			}
			private static int _ConnectionIdleTimeoutInterval = -1;

			/// <summary>
			/// The time in seconds for connection read timeouts.
			/// </summary>
			public static int ConnectionReceiveTimeoutInterval
			{
				get 
				{
					if (_ConnectionReceiveTimeoutInterval == -1)
						_ConnectionReceiveTimeoutInterval = DAL.CfgPara.GetReceiveTimeout();

					return _ConnectionReceiveTimeoutInterval;
				}
			}
			public static int _ConnectionReceiveTimeoutInterval = -1;


			/// <summary>
			/// The time in seconds for connection send timeouts.
			/// </summary>
			public static int ConnectionSendTimeoutInterval
			{
				get 
				{
					if (_connectionSendTimeoutInterval == -1)
						_connectionSendTimeoutInterval = DAL.CfgPara.GetSendTimeout();

					return _connectionSendTimeoutInterval;
				}
			}
			private static int _connectionSendTimeoutInterval = -1;
		}
	}
}