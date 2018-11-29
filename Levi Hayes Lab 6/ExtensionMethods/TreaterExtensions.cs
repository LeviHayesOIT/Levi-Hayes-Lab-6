using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessObjects;
using Levi_Hayes_Lab_6.Models;

namespace Levi_Hayes_Lab_6.ExtensionMethods
{
    public static class TreaterExtensions
    {
        public static Treater GetTreaterObject(this TreaterModel model )
        {
            Treater treater = new Treater();
            treater.id = model.TreaterID;
            treater.name = model.TreaterName;
            treater.favoriteCandy = new Candy();
            treater.favoriteCandy.id = model.CandyID;
            treater.favoriteCandy.productName = model.CandyName;
            treater.costume = new Costume();
            treater.costume.id = model.CostumeID;
            treater.costume.costume = model.CostumeName;

            return treater;
        }

        public static TreaterModel GetTreaterModel(this Treater treater)
        {
            TreaterModel model = new TreaterModel();
            model.TreaterID = treater.id;
            model.TreaterName = treater.name;
            model.CandyID = treater.favoriteCandy.id;
            model.CandyName = treater.favoriteCandy.productName;
            model.CostumeID = treater.costume.id;
            model.CostumeName = treater.costume.costume;

            return model;
        }
    }
}
