namespace Lab1View
{
    partial class ComponentsCheckForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.buttonCreateLongTextWord = new System.Windows.Forms.Button();
            this.buttonCreateLinearDiagramWord = new System.Windows.Forms.Button();
            this.longTextComponentWord = new NonVisualControlLibrary.LongTextComponentWord(this.components);
            this.linearDiagramWord = new NonVisualControlLibrary.LinearDiagramWord(this.components);
            this.tableWordFirst2Rows = new NonVisualControlLibrary.TableWordFirst2Rows(this.components);
            this.buttonCreateWordWithTable = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonCreateLongTextWord
            // 
            this.buttonCreateLongTextWord.Location = new System.Drawing.Point(12, 12);
            this.buttonCreateLongTextWord.Name = "buttonCreateLongTextWord";
            this.buttonCreateLongTextWord.Size = new System.Drawing.Size(181, 60);
            this.buttonCreateLongTextWord.TabIndex = 3;
            this.buttonCreateLongTextWord.Text = "Создать текстовый документ с большим текстом";
            this.buttonCreateLongTextWord.UseVisualStyleBackColor = true;
            this.buttonCreateLongTextWord.Click += new System.EventHandler(this.buttonCreateLongTextWord_Click);
            // 
            // buttonCreateLinearDiagramWord
            // 
            this.buttonCreateLinearDiagramWord.Location = new System.Drawing.Point(12, 95);
            this.buttonCreateLinearDiagramWord.Name = "buttonCreateLinearDiagramWord";
            this.buttonCreateLinearDiagramWord.Size = new System.Drawing.Size(181, 67);
            this.buttonCreateLinearDiagramWord.TabIndex = 4;
            this.buttonCreateLinearDiagramWord.Text = "Создать текстовый документ с линейной диаграммой";
            this.buttonCreateLinearDiagramWord.UseVisualStyleBackColor = true;
            this.buttonCreateLinearDiagramWord.Click += new System.EventHandler(this.buttonCreateLinearDiagramWord_Click);
            // 
            // buttonCreateWordWithTable
            // 
            this.buttonCreateWordWithTable.Location = new System.Drawing.Point(12, 190);
            this.buttonCreateWordWithTable.Name = "buttonCreateWordWithTable";
            this.buttonCreateWordWithTable.Size = new System.Drawing.Size(181, 58);
            this.buttonCreateWordWithTable.TabIndex = 5;
            this.buttonCreateWordWithTable.Text = "Создать текстовый документ с таблицей";
            this.buttonCreateWordWithTable.UseVisualStyleBackColor = true;
            this.buttonCreateWordWithTable.Click += new System.EventHandler(this.buttonCreateWordWithTable_Click);
            // 
            // ComponentsCheckForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(223, 261);
            this.Controls.Add(this.buttonCreateWordWithTable);
            this.Controls.Add(this.buttonCreateLinearDiagramWord);
            this.Controls.Add(this.buttonCreateLongTextWord);
            this.Name = "ComponentsCheckForm";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion
        private NonVisualControlLibrary.LongTextComponentWord longTextComponentWord;
        private System.Windows.Forms.Button buttonCreateLongTextWord;
        private NonVisualControlLibrary.LinearDiagramWord linearDiagramWord;
        private System.Windows.Forms.Button buttonCreateLinearDiagramWord;
        private NonVisualControlLibrary.TableWordFirst2Rows tableWordFirst2Rows;
        private System.Windows.Forms.Button buttonCreateWordWithTable;
    }
}

