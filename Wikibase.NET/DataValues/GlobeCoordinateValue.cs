﻿using System;
using System.Collections.Generic;
using System.Text;
using MinimalJson;

namespace Wikibase.DataValues
{
    /// <summary>
    /// Data value for globe coordinates
    /// </summary>
    public class GlobeCoordinateValue : DataValue
    {
        public const string LOBE_EARTH = "http://www.wikidata.org/entity/Q2";

        /// <summary>
        /// The latitude
        /// </summary>
        public double latitude { get; set; }

        /// <summary>
        /// The longitude
        /// </summary>
        public double longitude { get; set; }

        /// <summary>
        /// The altitude
        /// </summary>
        public object altitude { get; set; }

        /// <summary>
        /// The precision
        /// </summary>
        public double precision { get; set; }

        /// <summary>
        /// The globe on which the location resides
        /// </summary>
        public string globe { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="latitude">The latitude</param>
        /// <param name="longitude">The longitude</param>
        /// <param name="altitude">The altitude</param>
        /// <param name="precision">The precision</param>
        /// <param name="globe">The globe on which the location resides</param>
        public GlobeCoordinateValue(double latitude, double longitude, object altitude, double precision, string globe)
        {
            this.latitude = latitude;
            this.longitude = longitude;
            this.altitude = altitude;
            this.precision = precision;
            this.globe = globe;
        }

        internal GlobeCoordinateValue(JsonValue value)
        {
            JsonObject obj = value.asObject();
            this.latitude = obj.get("latitude").asDouble();
            this.longitude = obj.get("longitude").asDouble();
            this.altitude = obj.get("altitude");
            this.precision = obj.get("precision").asDouble();
            this.globe = obj.get("globe").asString();
        }

        public override string getType()
        {
            return "globecoordinate";
        }

        internal override JsonValue encode()
        {
            return new JsonObject()
                .add("latitude", latitude)
                .add("longitude", longitude)
                .add("altitude", altitude.ToString())
                .add("precision", precision)
                .add("globe", globe);
        }
    }
}
