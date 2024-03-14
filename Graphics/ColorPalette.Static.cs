﻿namespace ConsoleNexusEngine.Graphics;

using System.Linq;

public sealed partial record ColorPalette
{
    /// <summary>
    /// The default windows console color palette<br/>
    /// </summary>
    public static ColorPalette Default { get; }

    /// <summary>
    /// The color palette of IBM's original Color Graphics Adapter<br/>
    /// <see href="https://en.wikipedia.org/wiki/Color_Graphics_Adapter"/>
    /// </summary>
    public static ColorPalette CGA { get; }

    /// <summary>
    /// The color palette of the ZX Spectrum computer series (only 15 colors)<br/>
    /// <see href="https://en.wikipedia.org/wiki/ZX_Spectrum"/>
    /// </summary>
    public static ColorPalette ZXSpectrum { get; }

    /// <summary>
    /// The color palette of the Atari ST<br/>
    /// <see href="https://en.wikipedia.org/wiki/Atari_ST"/>
    /// </summary>
    public static ColorPalette AtariST { get; }

    /// <summary>
    /// The color palette of the MSX (only 15 colors)<br/>
    /// <see href="https://en.wikipedia.org/wiki/MSX2"/>
    /// </summary>
    public static ColorPalette MSX { get; }

    /// <summary>
    /// A grayscale color palette
    /// </summary>
    public static ColorPalette Grayscale { get; }

    /// <summary>
    /// The color palette of the Pico-8<br/>
    /// <see href="https://de.wikipedia.org/wiki/Pico-8"/>
    /// </summary>
    public static ColorPalette Pico8 { get; }

    /// <summary>
    /// The color palette of the old Windows<br/>
    /// <see href="https://de.wikipedia.org/wiki/Microsoft_Windows_1.0"/>
    /// </summary>
    public static ColorPalette Windows { get; }

    /// <summary>
    /// The color palette of the Commodore 64<br/>
    /// <see href="https://de.wikipedia.org/wiki/Commodore_64"/>
    /// </summary>
    public static ColorPalette Commodore64 { get; }

    static ColorPalette()
    {
        Default = new(
        [
            new NexusColor(0x000000),
            new NexusColor(0x000080),
            new NexusColor(0x008000),
            new NexusColor(0x800000),
            new NexusColor(0x008080),
            new NexusColor(0x800080),
            new NexusColor(0x808000),
            new NexusColor(0xC0C0C0),
            new NexusColor(0x808080),
            new NexusColor(0x0000FF),
            new NexusColor(0x00FF00),
            new NexusColor(0xFF0000),
            new NexusColor(0x00FFFF),
            new NexusColor(0xFF00FF),
            new NexusColor(0xFFFF00),
            new NexusColor(0xFFFFFF)
        ]);

        CGA = new(
        [
            new NexusColor(0x000000),
            new NexusColor(0x0000AA),
            new NexusColor(0x00AA00),
            new NexusColor(0x00AAAA),
            new NexusColor(0xAA0000),
            new NexusColor(0xAA00AA),
            new NexusColor(0xAA5500),
            new NexusColor(0xAAAAAA),
            new NexusColor(0x555555),
            new NexusColor(0x5555FF),
            new NexusColor(0x55FF55),
            new NexusColor(0x55FFFF),
            new NexusColor(0xFF5555),
            new NexusColor(0xFF55FF),
            new NexusColor(0xFFFF55),
            new NexusColor(0xFFFFFF)
        ]);

        ZXSpectrum = new(
        [
            new NexusColor(0x000000),
            new NexusColor(0x0000D8),
            new NexusColor(0x0000FF),
            new NexusColor(0xD80000),
            new NexusColor(0xFF0000),
            new NexusColor(0xD800D8),
            new NexusColor(0xFF00FF),
            new NexusColor(0x00D800),
            new NexusColor(0x00FF00),
            new NexusColor(0x00D8D8),
            new NexusColor(0x00FFFF),
            new NexusColor(0xD8D800),
            new NexusColor(0xFFFF00),
            new NexusColor(0xD8D8D8),
            new NexusColor(0xFFFFFF),
            new NexusColor()
        ]);

        AtariST = new(
        [
            new NexusColor(0x000000),
            new NexusColor(0x606060),
            new NexusColor(0xA0A0A0),
            new NexusColor(0xE0E0E0),
            new NexusColor(0xE0E020),
            new NexusColor(0xA06000),
            new NexusColor(0x20E0E0),
            new NexusColor(0x00A0A0),
            new NexusColor(0xE020E0),
            new NexusColor(0xA000A0),
            new NexusColor(0x20E020),
            new NexusColor(0x00A000),
            new NexusColor(0xE08080),
            new NexusColor(0xA00000),
            new NexusColor(0x6060E0),
            new NexusColor(0x0000A0)
        ]);

        MSX = new(
        [
            new NexusColor(0x000000),
            new NexusColor(0xCACACA),
            new NexusColor(0xFFFFFF),
            new NexusColor(0xB75E51),
            new NexusColor(0xD96459),
            new NexusColor(0xFE877C),
            new NexusColor(0xCAC15E),
            new NexusColor(0xDDCE85),
            new NexusColor(0x3CA042),
            new NexusColor(0x40B64A),
            new NexusColor(0x73CE7C),
            new NexusColor(0x5955DF),
            new NexusColor(0x7E75F0),
            new NexusColor(0x64DAEE),
            new NexusColor(0xB565B3),
            new NexusColor()
        ]);

        Grayscale = new(
        [
            new NexusColor(0x000000),
            new NexusColor(0x181818),
            new NexusColor(0x282828),
            new NexusColor(0x383838),
            new NexusColor(0x474747),
            new NexusColor(0x565656),
            new NexusColor(0x646464),
            new NexusColor(0x717171),
            new NexusColor(0x7E7E7E),
            new NexusColor(0x8C8C8C),
            new NexusColor(0x9B9B9B),
            new NexusColor(0xABABAB),
            new NexusColor(0xBDBDBD),
            new NexusColor(0xD1D1D1),
            new NexusColor(0xE7E7E7),
            new NexusColor(0xFFFFFF)
        ]);

        Pico8 = new(
        [
            new NexusColor(0x000000),
            new NexusColor(0x1D2B53),
            new NexusColor(0x7E2553),
            new NexusColor(0x008751),
            new NexusColor(0xAB5236),
            new NexusColor(0x5F574F),
            new NexusColor(0xC2C3C7),
            new NexusColor(0xFFF1E8),
            new NexusColor(0xFF004D),
            new NexusColor(0xFFA300),
            new NexusColor(0xFFEC27),
            new NexusColor(0x00E436),
            new NexusColor(0x29ADFF),
            new NexusColor(0x83769C),
            new NexusColor(0xFF77A8),
            new NexusColor(0xFFCCAA)
        ]);

        Windows = new(
        [
            new NexusColor(0x000000),
            new NexusColor(0x7E7E7E),
            new NexusColor(0xBEBEBE),
            new NexusColor(0xFFFFFF),
            new NexusColor(0x7E0000),
            new NexusColor(0xFE0000),
            new NexusColor(0x047E00),
            new NexusColor(0x06FF04),
            new NexusColor(0x7E7E00),
            new NexusColor(0xFFFF04),
            new NexusColor(0x00007E),
            new NexusColor(0x0000FF),
            new NexusColor(0x7E007E),
            new NexusColor(0xFE00FF),
            new NexusColor(0x047E7E),
            new NexusColor(0x06FFFF)
        ]);

        Commodore64 = new(
        [
            new NexusColor(0x000000),
            new NexusColor(0x626262),
            new NexusColor(0x898989),
            new NexusColor(0xADADAD),
            new NexusColor(0xFFFFFF),
            new NexusColor(0x9F4E44),
            new NexusColor(0xCB7E75),
            new NexusColor(0x6D5412),
            new NexusColor(0xA1683C),
            new NexusColor(0xC9D487),
            new NexusColor(0x9AE29B),
            new NexusColor(0x5CAB5E),
            new NexusColor(0x6ABFC6),
            new NexusColor(0x887ECB),
            new NexusColor(0x50459B),
            new NexusColor(0xA057A3)
        ]);
    }
}