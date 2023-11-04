﻿//===========================
// Copyright (c) Tarteeb LLC
// Managre quickly and easy
//===========================

using SmartManager.Models.Groups;
using SmartManager.Models.Students;
using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace SmartManager.Models.Statistics
{
    public class Statistic
    {
        public Guid Id { get; set; }
        public int MaleStudentsCount { get; set; }
        public int FemaleStudentsCount { get; set; }
        public int TotalStudentsCount { get; set; } 
        public int PaidStudentsCount { get; set; } 
        public double PaidStudentsPercentage { get; set; }
        public decimal TotalPayment { get; set; }
        [JsonIgnore]
        public IEnumerable<Student> Students { get; set; }
    }
}
