using System;

namespace UnityEngine.SocialPlatforms
{
	internal static class ActivePlatform
	{
		private static ISocialPlatform _active;

		internal static ISocialPlatform Instance
		{
			get
			{
				bool flag = ActivePlatform._active == null;
				if (flag)
				{
					ActivePlatform._active = ActivePlatform.SelectSocialPlatform();
				}
				return ActivePlatform._active;
			}
			set
			{
				ActivePlatform._active = value;
			}
		}

		private static ISocialPlatform SelectSocialPlatform()
		{
			return new Local();
		}
	}
}
