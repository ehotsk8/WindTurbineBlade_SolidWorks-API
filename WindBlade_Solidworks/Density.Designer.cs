namespace WindowsFormsApplication1
{
    partial class Density
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
            this.components = new System.ComponentModel.Container();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.плотность_ВоздухаDataSet = new WindowsFormsApplication1.Плотность_ВоздухаDataSet();
            this.таблица1BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.таблица1TableAdapter = new WindowsFormsApplication1.Плотность_ВоздухаDataSetTableAdapters.Таблица1TableAdapter();
            this.температураTCDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.плотностьКгм3DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.плотность_ВоздухаDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.таблица1BindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.температураTCDataGridViewTextBoxColumn,
            this.плотностьКгм3DataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.таблица1BindingSource;
            this.dataGridView1.Location = new System.Drawing.Point(2, 3);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(318, 327);
            this.dataGridView1.TabIndex = 0;
            // 
            // плотность_ВоздухаDataSet
            // 
            this.плотность_ВоздухаDataSet.DataSetName = "Плотность_ВоздухаDataSet";
            this.плотность_ВоздухаDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // таблица1BindingSource
            // 
            this.таблица1BindingSource.DataMember = "Таблица1";
            this.таблица1BindingSource.DataSource = this.плотность_ВоздухаDataSet;
            // 
            // таблица1TableAdapter
            // 
            this.таблица1TableAdapter.ClearBeforeFill = true;
            // 
            // температураTCDataGridViewTextBoxColumn
            // 
            this.температураTCDataGridViewTextBoxColumn.DataPropertyName = "Температура, t°C";
            this.температураTCDataGridViewTextBoxColumn.HeaderText = "Температура, t°C";
            this.температураTCDataGridViewTextBoxColumn.Name = "температураTCDataGridViewTextBoxColumn";
            this.температураTCDataGridViewTextBoxColumn.Width = 125;
            // 
            // плотностьКгм3DataGridViewTextBoxColumn
            // 
            this.плотностьКгм3DataGridViewTextBoxColumn.DataPropertyName = "Плотность, кг/м3";
            this.плотностьКгм3DataGridViewTextBoxColumn.HeaderText = "Плотность, кг/м3";
            this.плотностьКгм3DataGridViewTextBoxColumn.Name = "плотностьКгм3DataGridViewTextBoxColumn";
            this.плотностьКгм3DataGridViewTextBoxColumn.Width = 150;
            // 
            // Density
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(322, 340);
            this.Controls.Add(this.dataGridView1);
            this.Name = "Density";
            this.Text = "Плотность воздуха";
            this.Load += new System.EventHandler(this.Density_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.плотность_ВоздухаDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.таблица1BindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private Плотность_ВоздухаDataSet плотность_ВоздухаDataSet;
        private System.Windows.Forms.BindingSource таблица1BindingSource;
        private Плотность_ВоздухаDataSetTableAdapters.Таблица1TableAdapter таблица1TableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn температураTCDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn плотностьКгм3DataGridViewTextBoxColumn;
    }
}