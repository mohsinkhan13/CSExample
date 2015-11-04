﻿using Central.CSSContactAPI;
using CS.UI.Common.FormFactory;
using MYOB.CSS;
using MYOB.CSSInterface;
using MYOB.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CS.UI.Maintenance.DataAPIForm
{
    public partial class frmDataAPI : Form, ICSSDisplayMainArea
    {
        private DAL _centralDal;
        private CentralGateway _gateway;

        public frmDataAPI(DataAPI factory)
        {
            InitializeComponent();
        }

        public int CollectionID { get; set; }

        public void CloseForm(object sender, CSSCancelEventArgs e)
        {
            this.Close();
        }

        public SideBarGroups Register()
        {
            this.Show();
            return new SideBarGroups(string.Empty);
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            // recommeded in central
            _centralDal = CssContext.Instance.GetDAL(string.Empty) as DAL;
            
            _gateway = new CentralGateway(_centralDal);

        }

        private void cmdCreateIndividual_Click(object sender, EventArgs e)
        {

            var field = _gateway.FindExtraField("Turnover");
                        
            var i = new Individual() {
                LastName = "Smith" 
            };

            i.ExtraFields.Add(new ExtraValue() {
                ExtraFieldId = field.ExtraFieldId,
                Value = "100000"
            });

            _gateway.Save(i);

            CssContext.Instance.Host.OpenContact(i.ContactId);

        }

        private void cmdCreateClient_Click(object sender, EventArgs e)
        {

            var field = _gateway.FindExtraField("Turnover");

            var i = new Individual()
            {
                LastName = "Smith"
            };

            i.ExtraFields.Add(new ExtraValue()
            {
                ExtraFieldId = field.ExtraFieldId,
                Value = "100000"
            });

            _gateway.Save(i);

            var client = _gateway.ConvertContactToClient(i, "034756", CssContext.Instance.Host.EmployeeId);

            CssContext.Instance.Host.OpenContact(i.ContactId);

        }
    }
}
