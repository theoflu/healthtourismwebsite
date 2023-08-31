using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace website.Models.sınıflar
{
    public class plan_price
    {
        [Key]
        public int ID { get; set; }
        public string ytrk_tdv_tmnt { get; set; }
        public string knklm_tmnt { get; set; }
        public string ulasm_tmnt { get; set; }
        public string syht_tmnt { get; set; }
        public string hstlk { get; set; }
        public string kaza { get; set; }
        public string cndzn_yrdn_nkl { get; set; }
        public string acil_tbb_nkl { get; set; }
        public string knd_ulksnd_mdhl_tmnt { get; set; }
        public string kum_dhl_prim { get; set; }
        public string kumsz_prim { get; set; }
        public string rfktc_knklm_tmnt { get; set; }
        public string rfktc_ulsm_tmnt { get; set; }
        public string kum_rfktc_dhl { get; set; }
        public string rfktc_dhl { get; set; }

        public ICollection<kmplksyn_plan> kmplksyn_plans { get; set; }



    }
}