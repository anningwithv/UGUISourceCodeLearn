using System;
using System.Globalization;
using UnityEngine.Bindings;
using UnityEngine.Scripting;

namespace UnityEngine
{
	[NativeHeader("Runtime/Math/Color.h"), NativeClass("ColorRGBAf"), RequiredByNativeCode(Optional = true, GenerateProxy = true)]
	public struct Color : IEquatable<Color>, IFormattable
	{
		public float r;

		public float g;

		public float b;

		public float a;

		public static Color red
		{
			get
			{
				return new Color(1f, 0f, 0f, 1f);
			}
		}

		public static Color green
		{
			get
			{
				return new Color(0f, 1f, 0f, 1f);
			}
		}

		public static Color blue
		{
			get
			{
				return new Color(0f, 0f, 1f, 1f);
			}
		}

		public static Color white
		{
			get
			{
				return new Color(1f, 1f, 1f, 1f);
			}
		}

		public static Color black
		{
			get
			{
				return new Color(0f, 0f, 0f, 1f);
			}
		}

		public static Color yellow
		{
			get
			{
				return new Color(1f, 0.921568632f, 0.0156862754f, 1f);
			}
		}

		public static Color cyan
		{
			get
			{
				return new Color(0f, 1f, 1f, 1f);
			}
		}

		public static Color magenta
		{
			get
			{
				return new Color(1f, 0f, 1f, 1f);
			}
		}

		public static Color gray
		{
			get
			{
				return new Color(0.5f, 0.5f, 0.5f, 1f);
			}
		}

		public static Color grey
		{
			get
			{
				return new Color(0.5f, 0.5f, 0.5f, 1f);
			}
		}

		public static Color clear
		{
			get
			{
				return new Color(0f, 0f, 0f, 0f);
			}
		}

		public float grayscale
		{
			get
			{
				return 0.299f * this.r + 0.587f * this.g + 0.114f * this.b;
			}
		}

		public Color linear
		{
			get
			{
				return new Color(Mathf.GammaToLinearSpace(this.r), Mathf.GammaToLinearSpace(this.g), Mathf.GammaToLinearSpace(this.b), this.a);
			}
		}

		public Color gamma
		{
			get
			{
				return new Color(Mathf.LinearToGammaSpace(this.r), Mathf.LinearToGammaSpace(this.g), Mathf.LinearToGammaSpace(this.b), this.a);
			}
		}

		public float maxColorComponent
		{
			get
			{
				return Mathf.Max(Mathf.Max(this.r, this.g), this.b);
			}
		}

		public float this[int index]
		{
			get
			{
				float result;
				switch (index)
				{
				case 0:
					result = this.r;
					break;
				case 1:
					result = this.g;
					break;
				case 2:
					result = this.b;
					break;
				case 3:
					result = this.a;
					break;
				default:
					throw new IndexOutOfRangeException("Invalid Color index(" + index.ToString() + ")!");
				}
				return result;
			}
			set
			{
				switch (index)
				{
				case 0:
					this.r = value;
					break;
				case 1:
					this.g = value;
					break;
				case 2:
					this.b = value;
					break;
				case 3:
					this.a = value;
					break;
				default:
					throw new IndexOutOfRangeException("Invalid Color index(" + index.ToString() + ")!");
				}
			}
		}

		public Color(float r, float g, float b, float a)
		{
			this.r = r;
			this.g = g;
			this.b = b;
			this.a = a;
		}

		public Color(float r, float g, float b)
		{
			this.r = r;
			this.g = g;
			this.b = b;
			this.a = 1f;
		}

		public override string ToString()
		{
			return this.ToString(null, CultureInfo.InvariantCulture.NumberFormat);
		}

		public string ToString(string format)
		{
			return this.ToString(format, CultureInfo.InvariantCulture.NumberFormat);
		}

		public string ToString(string format, IFormatProvider formatProvider)
		{
			bool flag = string.IsNullOrEmpty(format);
			if (flag)
			{
				format = "F3";
			}
			return UnityString.Format("RGBA({0}, {1}, {2}, {3})", new object[]
			{
				this.r.ToString(format, formatProvider),
				this.g.ToString(format, formatProvider),
				this.b.ToString(format, formatProvider),
				this.a.ToString(format, formatProvider)
			});
		}

		public override int GetHashCode()
		{
			return this.GetHashCode();
		}

		public override bool Equals(object other)
		{
			bool flag = !(other is Color);
			return !flag && this.Equals((Color)other);
		}

		public bool Equals(Color other)
		{
			return this.r.Equals(other.r) && this.g.Equals(other.g) && this.b.Equals(other.b) && this.a.Equals(other.a);
		}

		public static Color operator +(Color a, Color b)
		{
			return new Color(a.r + b.r, a.g + b.g, a.b + b.b, a.a + b.a);
		}

		public static Color operator -(Color a, Color b)
		{
			return new Color(a.r - b.r, a.g - b.g, a.b - b.b, a.a - b.a);
		}

		public static Color operator *(Color a, Color b)
		{
			return new Color(a.r * b.r, a.g * b.g, a.b * b.b, a.a * b.a);
		}

		public static Color operator *(Color a, float b)
		{
			return new Color(a.r * b, a.g * b, a.b * b, a.a * b);
		}

		public static Color operator *(float b, Color a)
		{
			return new Color(a.r * b, a.g * b, a.b * b, a.a * b);
		}

		public static Color operator /(Color a, float b)
		{
			return new Color(a.r / b, a.g / b, a.b / b, a.a / b);
		}

		public static bool operator ==(Color lhs, Color rhs)
		{
			return lhs == rhs;
		}

		public static bool operator !=(Color lhs, Color rhs)
		{
			return !(lhs == rhs);
		}

		public static Color Lerp(Color a, Color b, float t)
		{
			t = Mathf.Clamp01(t);
			return new Color(a.r + (b.r - a.r) * t, a.g + (b.g - a.g) * t, a.b + (b.b - a.b) * t, a.a + (b.a - a.a) * t);
		}

		public static Color LerpUnclamped(Color a, Color b, float t)
		{
			return new Color(a.r + (b.r - a.r) * t, a.g + (b.g - a.g) * t, a.b + (b.b - a.b) * t, a.a + (b.a - a.a) * t);
		}

		internal Color RGBMultiplied(float multiplier)
		{
			return new Color(this.r * multiplier, this.g * multiplier, this.b * multiplier, this.a);
		}

		internal Color AlphaMultiplied(float multiplier)
		{
			return new Color(this.r, this.g, this.b, this.a * multiplier);
		}

		internal Color RGBMultiplied(Color multiplier)
		{
			return new Color(this.r * multiplier.r, this.g * multiplier.g, this.b * multiplier.b, this.a);
		}

		public static implicit operator Vector4(Color c)
		{
			return new Vector4(c.r, c.g, c.b, c.a);
		}

		public static implicit operator Color(Vector4 v)
		{
			return new Color(v.x, v.y, v.z, v.w);
		}

		public static void RGBToHSV(Color rgbColor, out float H, out float S, out float V)
		{
			bool flag = rgbColor.b > rgbColor.g && rgbColor.b > rgbColor.r;
			if (flag)
			{
				Color.RGBToHSVHelper(4f, rgbColor.b, rgbColor.r, rgbColor.g, out H, out S, out V);
			}
			else
			{
				bool flag2 = rgbColor.g > rgbColor.r;
				if (flag2)
				{
					Color.RGBToHSVHelper(2f, rgbColor.g, rgbColor.b, rgbColor.r, out H, out S, out V);
				}
				else
				{
					Color.RGBToHSVHelper(0f, rgbColor.r, rgbColor.g, rgbColor.b, out H, out S, out V);
				}
			}
		}

		private static void RGBToHSVHelper(float offset, float dominantcolor, float colorone, float colortwo, out float H, out float S, out float V)
		{
			V = dominantcolor;
			bool flag = V != 0f;
			if (flag)
			{
				bool flag2 = colorone > colortwo;
				float num;
				if (flag2)
				{
					num = colortwo;
				}
				else
				{
					num = colorone;
				}
				float num2 = V - num;
				bool flag3 = num2 != 0f;
				if (flag3)
				{
					S = num2 / V;
					H = offset + (colorone - colortwo) / num2;
				}
				else
				{
					S = 0f;
					H = offset + (colorone - colortwo);
				}
				H /= 6f;
				bool flag4 = H < 0f;
				if (flag4)
				{
					H += 1f;
				}
			}
			else
			{
				S = 0f;
				H = 0f;
			}
		}

		public static Color HSVToRGB(float H, float S, float V)
		{
			return Color.HSVToRGB(H, S, V, true);
		}

		public static Color HSVToRGB(float H, float S, float V, bool hdr)
		{
			Color white = Color.white;
			bool flag = S == 0f;
			if (flag)
			{
				white.r = V;
				white.g = V;
				white.b = V;
			}
			else
			{
				bool flag2 = V == 0f;
				if (flag2)
				{
					white.r = 0f;
					white.g = 0f;
					white.b = 0f;
				}
				else
				{
					white.r = 0f;
					white.g = 0f;
					white.b = 0f;
					float num = H * 6f;
					int num2 = (int)Mathf.Floor(num);
					float num3 = num - (float)num2;
					float num4 = V * (1f - S);
					float num5 = V * (1f - S * num3);
					float num6 = V * (1f - S * (1f - num3));
					switch (num2)
					{
					case -1:
						white.r = V;
						white.g = num4;
						white.b = num5;
						break;
					case 0:
						white.r = V;
						white.g = num6;
						white.b = num4;
						break;
					case 1:
						white.r = num5;
						white.g = V;
						white.b = num4;
						break;
					case 2:
						white.r = num4;
						white.g = V;
						white.b = num6;
						break;
					case 3:
						white.r = num4;
						white.g = num5;
						white.b = V;
						break;
					case 4:
						white.r = num6;
						white.g = num4;
						white.b = V;
						break;
					case 5:
						white.r = V;
						white.g = num4;
						white.b = num5;
						break;
					case 6:
						white.r = V;
						white.g = num6;
						white.b = num4;
						break;
					}
					bool flag3 = !hdr;
					if (flag3)
					{
						white.r = Mathf.Clamp(white.r, 0f, 1f);
						white.g = Mathf.Clamp(white.g, 0f, 1f);
						white.b = Mathf.Clamp(white.b, 0f, 1f);
					}
				}
			}
			return white;
		}
	}
}
