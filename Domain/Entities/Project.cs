﻿using System.ComponentModel.DataAnnotations;
using Domain.Enum;
using Newtonsoft.Json;

namespace Domain;

public class Project
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public Guid OwnerId { get; set; }
    public WorkStatus Status { get; set; }
    public DateTime DateStart { get; set; }
    public DateTime DateEnd { get; set; }
}