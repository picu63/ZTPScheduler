﻿using EnduroLibrary;
using System;
using System.Collections.Generic;
using System.Text;

namespace EnduroCalculator.Interfaces
{
    public interface ITrackCalculator
    {
        List<Track> GetDrives(ICollection<TrackPoint> trackPoints);
        ICollection<List<TrackPoint>> GetClimbingSections(ICollection<TrackPoint> trackPoints, double slopeDegree= 5);
        ICollection<List<TrackPoint>> GetDescentSections(ICollection<TrackPoint> trackPoints, double slopeDegree = 5);
        ICollection<List<TrackPoint>> GetFlatSections(ICollection<TrackPoint> trackPoints, double maxSlopeDegree = 5);
        IEnumerable<double> GetAllVelocities(IEnumerable<TrackPoint> trackPoints);
        double GetVelocity(TrackPoint startPoint, TrackPoint endPoint);
    }
}
