namespace CaterUI
{
    partial class FormOrderPay
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label7 = new System.Windows.Forms.Label();
            this.lblPayMoneyDiscount = new System.Windows.Forms.Label();
            this.cbkMember = new System.Windows.Forms.CheckBox();
            this.cbkMoney = new System.Windows.Forms.CheckBox();
            this.lblDiscount = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblTypeTitle = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblMoney = new System.Windows.Forms.Label();
            this.lblPayMoney = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.txtPhone = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtId = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.btnOrderPay = new System.Windows.Forms.Button();
            this.gbMember = new System.Windows.Forms.GroupBox();
            this.gbMember.SuspendLayout();
            this.SuspendLayout();
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(15, 175);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(35, 12);
            this.label7.TabIndex = 15;
            this.label7.Text = "Total";
            // 
            // lblPayMoneyDiscount
            // 
            this.lblPayMoneyDiscount.AutoSize = true;
            this.lblPayMoneyDiscount.Location = new System.Drawing.Point(223, 175);
            this.lblPayMoneyDiscount.Name = "lblPayMoneyDiscount";
            this.lblPayMoneyDiscount.Size = new System.Drawing.Size(11, 12);
            this.lblPayMoneyDiscount.TabIndex = 22;
            this.lblPayMoneyDiscount.Text = "0";
            // 
            // cbkMember
            // 
            this.cbkMember.AutoSize = true;
            this.cbkMember.Location = new System.Drawing.Point(9, 8);
            this.cbkMember.Name = "cbkMember";
            this.cbkMember.Size = new System.Drawing.Size(84, 16);
            this.cbkMember.TabIndex = 16;
            this.cbkMember.Text = "Membership";
            this.cbkMember.UseVisualStyleBackColor = true;
            this.cbkMember.CheckedChanged += new System.EventHandler(this.cbkMember_CheckedChanged);
            // 
            // cbkMoney
            // 
            this.cbkMoney.AutoSize = true;
            this.cbkMoney.Location = new System.Drawing.Point(145, 84);
            this.cbkMoney.Name = "cbkMoney";
            this.cbkMoney.Size = new System.Drawing.Size(84, 16);
            this.cbkMoney.TabIndex = 10;
            this.cbkMoney.Text = "Use Credit";
            this.cbkMoney.UseVisualStyleBackColor = true;
            // 
            // lblDiscount
            // 
            this.lblDiscount.AutoSize = true;
            this.lblDiscount.Location = new System.Drawing.Point(205, 109);
            this.lblDiscount.Name = "lblDiscount";
            this.lblDiscount.Size = new System.Drawing.Size(11, 12);
            this.lblDiscount.TabIndex = 9;
            this.lblDiscount.Text = "1";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(143, 109);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 12);
            this.label6.TabIndex = 8;
            this.label6.Text = "DisCount：";
            // 
            // lblTypeTitle
            // 
            this.lblTypeTitle.AutoSize = true;
            this.lblTypeTitle.Location = new System.Drawing.Point(81, 111);
            this.lblTypeTitle.Name = "lblTypeTitle";
            this.lblTypeTitle.Size = new System.Drawing.Size(53, 12);
            this.lblTypeTitle.TabIndex = 7;
            this.lblTypeTitle.Text = "普通会员";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 109);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(83, 12);
            this.label4.TabIndex = 6;
            this.label4.Text = "Member type：";
            // 
            // lblMoney
            // 
            this.lblMoney.AutoSize = true;
            this.lblMoney.Location = new System.Drawing.Point(69, 85);
            this.lblMoney.Name = "lblMoney";
            this.lblMoney.Size = new System.Drawing.Size(11, 12);
            this.lblMoney.TabIndex = 5;
            this.lblMoney.Text = "0";
            // 
            // lblPayMoney
            // 
            this.lblPayMoney.AutoSize = true;
            this.lblPayMoney.Location = new System.Drawing.Point(77, 175);
            this.lblPayMoney.Name = "lblPayMoney";
            this.lblPayMoney.Size = new System.Drawing.Size(11, 12);
            this.lblPayMoney.TabIndex = 18;
            this.lblPayMoney.Text = "0";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 85);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "Credit：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "MemberID：";
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(130, 206);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(95, 23);
            this.btnCancel.TabIndex = 20;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // txtPhone
            // 
            this.txtPhone.Location = new System.Drawing.Point(69, 52);
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.Size = new System.Drawing.Size(176, 21);
            this.txtPhone.TabIndex = 3;
            this.txtPhone.Leave += new System.EventHandler(this.txtPhone_Leave);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "Phone：";
            // 
            // txtId
            // 
            this.txtId.Location = new System.Drawing.Point(69, 19);
            this.txtId.Name = "txtId";
            this.txtId.Size = new System.Drawing.Size(176, 21);
            this.txtId.TabIndex = 1;
            this.txtId.Leave += new System.EventHandler(this.txtId_Leave);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(124, 175);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(101, 12);
            this.label8.TabIndex = 21;
            this.label8.Text = "Discount Total：";
            // 
            // btnOrderPay
            // 
            this.btnOrderPay.Location = new System.Drawing.Point(17, 206);
            this.btnOrderPay.Name = "btnOrderPay";
            this.btnOrderPay.Size = new System.Drawing.Size(95, 23);
            this.btnOrderPay.TabIndex = 19;
            this.btnOrderPay.Text = "CheckOut";
            this.btnOrderPay.UseVisualStyleBackColor = true;
            this.btnOrderPay.Click += new System.EventHandler(this.btnOrderPay_Click);
            // 
            // gbMember
            // 
            this.gbMember.Controls.Add(this.cbkMoney);
            this.gbMember.Controls.Add(this.lblDiscount);
            this.gbMember.Controls.Add(this.label6);
            this.gbMember.Controls.Add(this.lblTypeTitle);
            this.gbMember.Controls.Add(this.label4);
            this.gbMember.Controls.Add(this.lblMoney);
            this.gbMember.Controls.Add(this.label3);
            this.gbMember.Controls.Add(this.txtPhone);
            this.gbMember.Controls.Add(this.label2);
            this.gbMember.Controls.Add(this.txtId);
            this.gbMember.Controls.Add(this.label1);
            this.gbMember.Location = new System.Drawing.Point(8, 30);
            this.gbMember.Name = "gbMember";
            this.gbMember.Size = new System.Drawing.Size(257, 133);
            this.gbMember.TabIndex = 17;
            this.gbMember.TabStop = false;
            this.gbMember.Text = "MemberInfo";
            // 
            // FormOrderPay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(278, 243);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.lblPayMoneyDiscount);
            this.Controls.Add(this.cbkMember);
            this.Controls.Add(this.lblPayMoney);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.btnOrderPay);
            this.Controls.Add(this.gbMember);
            this.Name = "FormOrderPay";
            this.Text = "FormOrderPay";
            this.Load += new System.EventHandler(this.FormOrderPay_Load);
            this.gbMember.ResumeLayout(false);
            this.gbMember.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblPayMoneyDiscount;
        private System.Windows.Forms.CheckBox cbkMember;
        private System.Windows.Forms.CheckBox cbkMoney;
        private System.Windows.Forms.Label lblDiscount;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblTypeTitle;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblMoney;
        private System.Windows.Forms.Label lblPayMoney;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.TextBox txtPhone;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtId;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnOrderPay;
        private System.Windows.Forms.GroupBox gbMember;
    }
}