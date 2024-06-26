﻿namespace ConsoleNexusEngine.Graphics;

using Figgle;
using System.Linq;

/// <summary>
/// Represents a figgle text in the console
/// </summary>
public sealed record NexusFiggleText
{
    internal readonly int _longestStringLength;
    internal readonly string[] _value;

    /// <summary>
    /// The text lines itself
    /// </summary>
    public IReadOnlyCollection<string> Value => _value.AsReadOnly();

    /// <summary>
    /// The foreground color of the text
    /// </summary>
    public NexusColor Foreground { get; }

    /// <summary>
    /// The background color of the text, <see langword="null"/> if the console background color should be used
    /// </summary>
    public NexusColor? Background { get; }

    /// <summary>
    /// The figgle font of the text
    /// </summary>
    public FiggleFont FiggleFont { get; }

    /// <summary>
    /// Initializes a new console text in figgle font
    /// </summary>
    /// <param name="value">The text itself</param>
    /// <param name="figgleFont">The Figgle Font that is used on the <paramref name="value"/></param>
    /// <param name="foreground">The foreground color of the text</param>
    /// <param name="background">The background color of the text, <see langword="null"/> if the console background color should be used</param>
    public NexusFiggleText(string value, FiggleFont figgleFont, in NexusColor foreground, in NexusColor? background = null)
    {
        _longestStringLength = InitText(value, figgleFont, out _value);
        Foreground = foreground;
        Background = background;
        FiggleFont = figgleFont;
    }

    /// <summary>
    /// Initializes a new console text in figgle font
    /// </summary>
    /// <param name="value">The text itself</param>
    /// <param name="figgleFont">The Figgle Font that is used on the <paramref name="value"/></param>
    /// <param name="foreground">The foreground color of the text</param>
    /// <param name="background">The background color of the text, <see langword="null"/> if the console background color should be used</param>
    public NexusFiggleText(in char value, FiggleFont figgleFont, in NexusColor foreground, in NexusColor? background = null)
        : this(value.ToString(), figgleFont, foreground, background) { }

    /// <summary>
    /// Initializes a new console text in figgle font
    /// </summary>
    /// <param name="value">The text itself</param>
    /// <param name="figgleFont">The Figgle Font that is used on the <paramref name="value"/></param>
    /// <param name="foreground">The foreground color of the text</param>
    /// <param name="background">The background color of the text, <see langword="null"/> if the console background color should be used</param>
    public NexusFiggleText(object? value, FiggleFont figgleFont, in NexusColor foreground, in NexusColor? background = null)
        : this(value?.ToString() ?? "", figgleFont, foreground, background) { }

    private static int InitText(string value, FiggleFont font, out string[] values)
    {
        values = font.Render(value).Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);

        return values.Aggregate("", (max, val) => val.Length > max.Length ? val : max).Length;
    }
}