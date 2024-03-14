﻿namespace ConsoleNexusEngine.Graphics;

using System.Collections.Immutable;

/// <summary>
/// Uses the HSP color space for image processing
/// </summary>
public sealed class NexusHspProcessor : NexusImageProcessor
{
    private const double RConst = 0.299;
    private const double GConst = 0.587;
    private const double BConst = 0.114;

    private readonly ImmutableArray<HSP> _colors;
    
    /// <inheritdoc/>
    public NexusHspProcessor(ColorPalette colorPalette) : base(colorPalette)
    {
        var builder = new SpanBuilder<HSP>();

        foreach (var color in _colorPalette.Colors.Values)
        {
            builder.Append(RgbToHsp(color));
        }

        _colors = ImmutableArray.Create(builder.AsReadOnlySpan());
    }
    
    /// <inheritdoc/>
    public override NexusColor Process(in NexusColor targetColor)
    {
        var nearestColorIndex = 0;
        var minDistance = double.MaxValue;

        var targetHsp = RgbToHsp(targetColor);

        for (int i = 0; i < _colors.Length; i++)
        {
            var distance = CalculateHspDistance(targetHsp, _colors[i]);

            if (distance < minDistance)
            {
                minDistance = distance;
                nearestColorIndex = i;
            }
        }

        return _colorPalette[nearestColorIndex];
    }

    private static double CalculateHspDistance(in HSP hsp1, in HSP hsp2)
    {
        var hueDiff = Math.Abs(hsp1.H - hsp2.H);

        if (hueDiff > 180) hueDiff = 360 - hueDiff;

        return Math.Sqrt(Math.Pow(hueDiff, 2) + Math.Pow(hsp1.S - hsp2.S, 2) + Math.Pow(3 * (hsp1.P - hsp2.P), 2));
    }

    private static HSP RgbToHsp(in NexusColor color)
    {
        var r = color.R / 255d;
        var g = color.G / 255d;
        var b = color.B / 255d;

        var hue = 0d;
        var saturation = 0d;

        if (r != g)
        {
            var min = Math.Min(r, Math.Min(g, b));
            var max = Math.Max(r, Math.Max(g, b));
            var delta = max - min;

            saturation = 1 - min / max;

            if (max == r)
            {
                hue = 6 / 6 - 1 / 6 * (b - g) / delta;
            }
            else if (max == g)
            {
                hue = 2 / 6 - 1 / 6 * (r - b) / delta;
            }
            else
            {
                hue = 4 / 6 - 1 / 6 * (g - r) / delta;
            }

            hue %= 1;
        }

        return new HSP
        {
            H = hue,
            S = saturation,
            P = Math.Sqrt(Math.Pow(r, 2) * RConst + Math.Pow(g, 2) * GConst + Math.Pow(b, 2) * BConst)
        };
    }

    private readonly record struct HSP
    {
        public required double H { get; init; }
        public required double S { get; init; }
        public required double P { get; init; }
    }
}