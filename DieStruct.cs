using System;
using System.Collections.Generic;

struct Die
{
    public int Faces { get; }
    public double[] Probabilities { get; }

    public Die(int faces, double[] probabilities)
    {
        Faces = faces;
        Probabilities = probabilities;
    }
}