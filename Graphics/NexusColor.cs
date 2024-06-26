﻿namespace ConsoleNexusEngine.Graphics;

/// <summary>
/// Represents a RGB color
/// </summary>
public readonly partial record struct NexusColor : ISpanParsable<NexusColor>, IParsable<NexusColor>
{
    private readonly uint _value;

    /// <summary>
    /// Red component of the color
    /// </summary>
    public readonly byte R => (byte)(_value >> 16);

    /// <summary>
    /// Green component of the color
    /// </summary>
    public readonly byte G => (byte)(_value >> 8);

    /// <summary>
    /// Blue component of the color
    /// </summary>
    public readonly byte B => (byte)_value;

    internal NexusColor(in uint color) => _value = color;

    /// <summary>
    /// Initializes a black color
    /// </summary>
    public NexusColor() : this(0x000000) { }

    /// <summary>
    /// Initializes a color from RGB
    /// </summary>
    /// <param name="r">Red component</param>
    /// <param name="g">Green component</param>
    /// <param name="b">Blue component</param>
    public NexusColor(in byte r, in byte g, in byte b) : this(FromRgb(r, g, b)) { }

    /// <summary>
    /// 1.0 is <see cref="White"/>, 0.0 is <see cref="Black"/>
    /// </summary>
    /// <returns><see cref="float"/> between 0.0 and 1.0</returns>
    public readonly float GetLuminance()
        => (0.2126f * R + 0.7152f * G + 0.0722f * B) / 255f;

    /// <summary>
    /// Format: "[R={<see cref="R"/>},G={<see cref="G"/>},B={<see cref="B"/>}]"
    /// </summary>
    /// <returns><see cref="string"/></returns>
    public override readonly string ToString()
        => $"[R={R},G={G},B={B}]";
}