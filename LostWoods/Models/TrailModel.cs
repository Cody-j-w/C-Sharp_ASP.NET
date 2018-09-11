using System.ComponentModel.DataAnnotations;
using System.Collections;
using System;
namespace LostWoods.Models

{
    public class Trail
    {
        [Required (ErrorMessage = "Please provide the Trail Name")]
        [MinLength(3, ErrorMessage = "Trail Name must be at least three characters long!")]
        [MaxLength(32, ErrorMessage = "Trail Name cannot be more than 32 characters!")]
        public string Name{get; set;}

        [MinLength(10, ErrorMessage = "Trail Description must be at least 10 characters")]
        [MaxLength(255, ErrorMessage = "Trail Description cannot be more than 255 characters")]
        public string Desc{get; set;}

        [Required (ErrorMessage = "Please provide the trail length")]
        public decimal? Length{get; set;}

        [Required (ErrorMessage = "Please provide the trail elevation change")]
        public int? Elevation{get; set;}

        [Required (ErrorMessage = "Please provide Longitudinal coordinates")]
        [RegularExpression (@"[-+]?(180(\.0+)?|((1[0-7]\d)|([1-9]?\d))(\.\d+)?)$", ErrorMessage="Please provide valid longitudinal coordinates")]
        public double? Longitude{get; set;}

        [Required (ErrorMessage = "Please provide Latitudinal coordinates")]
        [RegularExpression (@"^[-+]?([1-8]?\d(\.\d+)?|90(\.0+)?)$", ErrorMessage = "Please provide valid latitudinal coordinates")]
        public double? Latitude{get; set;}
    }

    public class TrailList : IEnumerable
    {
        private Trail[] _trails;
        public TrailList(Trail[] tArray)
        {
            _trails = new Trail[tArray.Length];

            for(int i = 0; i<tArray.Length; i++)
            {
                _trails[i] = tArray[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return (IEnumerator) GetEnumerator();
        }

        public TrailListEnum GetEnumerator()
        {
            return new TrailListEnum(_trails);
        }
    }

    public class TrailListEnum : IEnumerator
    {
        public Trail[] _trails;

        int position = -1;

        public TrailListEnum(Trail[] list)
        {
            _trails = list;
        }

        public bool MoveNext()
        {
            position++;
            return (position < _trails.Length);
        }

        public void Reset()
        {
            position = -1;
        }

        object IEnumerator.Current{
            get
            {
                try
                {
                    return _trails[position];
                }
                catch(IndexOutOfRangeException)
                {
                    throw new InvalidOperationException();
                }
            }
        }
    }
}