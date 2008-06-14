using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Tao.OpenGl;
using Tao.Platform;
using testTAO;


namespace _DTeaching
{
    public partial class Form1 : Form
    {
        #region Declaration
        public enum View
        {
            Orthogonal,
            Perspective
        }
        public String m_strView;
        private float zoom;
        // Variables of pnRGB  
        #region Variables of pnRGB
        public enum Choice
        {
            Object,
            Background
        }
        public String m_strChoice;

        int m_iRedBack;
        int m_iGreenBack;
        int m_iBlueBack;
        int m_iAlphaBack;

        int m_iRedObject;
        int m_iGreenObject;
        int m_iBlueObject;
        int m_iAlphaObject;
        #endregion
        #region Varables of pnRotate

        //Variables of Plane:
        float m_fRotX_Plane;
        float m_fRotY_Plane;
        float m_fRotZ_Plane;

        //Variables of Object:
        float m_fRotX_Object;
        float m_fRotY_Object;
        float m_fRotZ_Object;
        float m_fRotany_Object;

        // Gia tri hien thoi cua trackBar
        int m_itrackBarRotx;
        int m_itrackBarRoty;
        int m_itrackBarRotz;
        int m_itrackBarRotany;

        #endregion
        #region Variables of pnTranslate
        float m_fTransX;
        float m_fTransY;
        float m_fTransZ;

        // Gia tri hien thoi cua trackBar
        int m_itrackBarTransX;
        int m_itrackBarTransY;
        int m_itrackBarTransZ;

        #endregion
        #region Variables of pnScale
        float m_fScaX;
        float m_fScaY;
        float m_fScaZ;

        // Gia tri hien thoi cua trackBar
        int m_itrackBarScaX;
        int m_itrackBarScaY;
        int m_itrackBarScaZ;
        #endregion
        #region Variables of pnLighting
        float m_fLightingX;
        float m_fLightingY;
        float m_fLightingZ;

        // Gia tri hien thoi cua trackBar
        int m_itrackBarLightingX;
        int m_itrackBarLightingY;
        int m_itrackBarLightingZ;
        #endregion

        // Fog
        int m_iRedFog = 0;
        int m_iGreenFog = 0;
        int m_iBlueFog = 0;

        private int nRange = 100;
        private _Ground ground;
        private List<_ObjectOpenGL> lstObj;// Chua cac hinh khoi
        private List<_LightSource> lstLightSource; // Chua cac nguon sang
        private List<_Shadow> lstShadow; // Chua cac ma tran de tao bong
        // so phan tu cua lstShadow = so phan tu cua lstLightSource
        private List<_Vector> lstVector;
        private _Fog fog;
        private _Texture texture;
        private _UnitAxes unitaxes;



        #endregion
        public Form1()
        {
            InitializeComponent();
            simpleOpenGlControlPreViewcurrent.InitializeContexts();

            //            ChangeSize();
            #region Set default cho cac doi tuong ve.
            SetupRC();
            zoom = 1;
            lstObj = new List<_ObjectOpenGL>();
            lstShadow = new List<_Shadow>();
            texture = new _Texture("CONQUE~1.jpg");
            texture.Enable = false;
            lstLightSource = new List<_LightSource>();
            lstLightSource.Add(new _LightSource(0));
            lstLightSource[0].SetColor(255, 255, 255);
            lstLightSource[0].Enable = false;

            
            lstVector = new List<_Vector>();
            lstVector.Add(new _Vector(new _Vector3D(-20, 10, 0), new _Vector3D(45, 50, 20)));
            lstVector[0].Enable = false;
            ground = new _Ground(nRange);
            lstShadow.Add(new _Shadow(ground));
            lstShadow[0].CalculatorMatrix(lstLightSource[0]);
            lstShadow[0].Enable = false;
            fog = new _Fog();
            fog.Enable = false;
            unitaxes = new _UnitAxes(nRange);
            #endregion
            //texture.Enable = false;

            m_strView = "Orthogonal";

            //Hien thi panel mac dinh: panel RGB.
            // pnRGB.Dock = DockStyle.Right;
            //pnRGB.Visible = true;
            #region Set default for pnRGB
            m_iRedBack = 0;
            m_iGreenBack = 0;
            m_iBlueBack = 0;
            m_iAlphaBack = 0;

            m_iRedObject = 255;
            m_iGreenObject = 255;
            m_iBlueObject = 255;
            m_iAlphaObject = 255;

            m_strChoice = "Background";
            #endregion
            #region Set default for tabControlRotate
            m_fRotX_Plane = 0;
            m_fRotY_Plane = 0;
            m_fRotZ_Plane = 0;

            m_fRotX_Object = 0;
            m_fRotY_Object = 0;
            m_fRotZ_Object = 0;
            m_fRotany_Object = 0;
            m_itrackBarRotz = 0;

            m_itrackBarRotx = 0;
            m_itrackBarRoty = 0;
            m_itrackBarRotz = 0;

            #endregion

            #region Set default for pnTranslate
            m_fTransX = 0;
            m_fTransY = 0;
            m_fTransZ = 0;

            m_itrackBarTransX = 0;
            m_itrackBarTransY = 0;
            m_itrackBarTransZ = 0;
            #endregion
            #region Set default for pnScale
            m_fScaX = 1;
            m_fScaY = 1;
            m_fScaZ = 1;

            m_itrackBarScaX = 1;
            m_itrackBarScaY = 1;
            m_itrackBarScaZ = 1;
            #endregion
            #region Set default for Lighting.
            m_fLightingX = 0;
            m_fLightingY = 0;
            m_fLightingZ = 0;

            // Gia tri hien thoi cua trackBar
            m_itrackBarLightingX = 0;
            m_itrackBarLightingY = 0;
            m_itrackBarLightingZ = 0;
            #endregion

            Gl.glClearColor(0.0f, 0.0f, 0.0f, 0.0f);
            Gl.glMatrixMode(Gl.GL_PROJECTION);

            Gl.glLoadIdentity();

            simpleOpenGlControlPreViewcurrent.Height += 1;
        }

        #region Proceed simpleOpenGlControl1
        private void GL_Paint()
        {
            Boolean bDepth = true;
            // Clear the window and the depth buffer
            Gl.glClear(Gl.GL_COLOR_BUFFER_BIT | Gl.GL_DEPTH_BUFFER_BIT);


            // Enable depth testing if flag is set
            Gl.glEnable(Gl.GL_DEPTH_TEST);

            Gl.glPushMatrix();
            Gl.glTranslatef(0, 0, -0.3f * nRange);

            // Quay mat phang:
            Gl.glRotatef(m_fRotX_Plane, 1, 0, 0);
            Gl.glRotatef(m_fRotY_Plane, 0, 1, 0);
            Gl.glRotatef(m_fRotZ_Plane, 0, 0, 1);

            Gl.glScalef(zoom, zoom, zoom);
            fog.Apply();
            // Ve mat dat
            ground.Draw();
            // Ve truc toa do
            unitaxes.Draw();
            
            for (int i = 0; i < lstVector.Count; ++i)
                lstVector[i].Draw();

            // Ve bong
            for (int i = 0; i < lstShadow.Count; ++i)
                lstShadow[i].Draw(lstObj);

            // Ve va dat nguon sang
            for (int i = 0; i < lstLightSource.Count; ++i)
                lstLightSource[i].Draw();

            // Ve cac doi tuong
            for (int i = 0; i < lstObj.Count; ++i)
            {             
                lstObj[i].Draw();
            }

            Gl.glPopMatrix();
        }

        private void simpleOpenGlControl1_Paint(object sender, PaintEventArgs e)
        {
            GL_Paint();
        }
        private void simpleOpenGlControl1_Resize(object sender, EventArgs e)
        {
            SetView();
        }
        #endregion

        #region Proceed toolStrip (Toolbar)
        private void toolStripCone_Click(object sender, EventArgs e)
        {
            // Moi lan add mot hinh -> moi lan them hinh moi thi
            // xoa doi tuong cu trong obj.
            if (lstObj.Count > 0)
                lstObj.RemoveAt(0);

            // add doi tuong moi.
            lstObj.Add(new _Cone(30, 70, 100, 100));

            simpleOpenGlControlPreViewcurrent.Draw();

            //simpleOpenGlControlCurrent.Draw();
            rbObjectRGB.Enabled = true;

            // Set default color
            if (m_strChoice == Choice.Object.ToString())
                rbWhite.Checked = true;
        }
        private void toolStripSph_Click(object sender, EventArgs e)
        {
            // Moi lan add mot hinh -> moi lan them hinh moi thi
            // xoa doi tuong cu trong obj.
            if (lstObj.Count > 0)
                lstObj.RemoveAt(0);

            // add doi tuong moi.
            lstObj.Add(new _Sphere(30, 70, 100, 100));

            simpleOpenGlControlPreViewcurrent.Draw();

            //simpleOpenGlControlCurrent.Draw();
            rbObjectRGB.Enabled = true;

            // Set default color
            if (m_strChoice == Choice.Object.ToString())
                rbWhite.Checked = true;
        }
        private void toolStripCubic_Click(object sender, EventArgs e)
        {
            // Moi lan add mot hinh -> moi lan them hinh moi thi
            // xoa doi tuong cu trong obj.
            if (lstObj.Count > 0)
                lstObj.RemoveAt(0);

            // add doi tuong moi.
            lstObj.Add(new _Cubic(0, 0, 0, 30));

            simpleOpenGlControlPreViewcurrent.Draw();

            //simpleOpenGlControlCurrent.Draw();
            rbObjectRGB.Enabled = true;

            // Set default color
            if (m_strChoice == Choice.Object.ToString())
                rbWhite.Checked = true;
        }
        private void toolStripCyl_Click(object sender, EventArgs e)
        {
            // Moi lan add mot hinh -> moi lan them hinh moi thi
            // xoa doi tuong cu trong obj.
            if (lstObj.Count > 0)
                lstObj.RemoveAt(0);

            // add doi tuong moi.
            lstObj.Add(new _Cylinder(30, 70, 100, 100));

            simpleOpenGlControlPreViewcurrent.Draw();

            //simpleOpenGlControlCurrent.Draw();
            rbObjectRGB.Enabled = true;

            // Set default color
            if (m_strChoice == Choice.Object.ToString())
                rbWhite.Checked = true;
        }

        private void toolStripOrtho_Click(object sender, EventArgs e)
        {
            toolStripPers.Checked = false;
            toolStripOrtho.Checked = true;
        }
        private void toolStripPers_Click(object sender, EventArgs e)
        {
            toolStripOrtho.Checked = false;
            toolStripPers.Checked = true;
        }
        private void toolStripOrtho_CheckedChanged(object sender, EventArgs e)
        {
            if (toolStripOrtho.Checked == true)
                m_strView = "Orthogonal";
            SetView();
        }
        private void toolStripPers_CheckedChanged(object sender, EventArgs e)
        {
            if (toolStripPers.Checked == true)
                m_strView = "Perspective";
            SetView();
        }
        private void toolStripBnRGB_Click(object sender, EventArgs e)
        {
            panel2.Visible = false;
            gbRGBFog.Visible = false;
            pnLighting.Visible = false;
            pnSca.Visible = false;
            pnTrans.Visible = false;
            tabControlRot.Visible = false;
            pnRGB.Dock = DockStyle.Right;
            pnRGB.Visible = true;
        }
        private void toolStripBnRot_Click(object sender, EventArgs e)
        {
            panel2.Visible = false;
            gbRGBFog.Visible = false;
            pnLighting.Visible = false;
            pnSca.Visible = false;
            pnTrans.Visible = false;
            pnRGB.Visible = false;
            tabControlRot.Dock = DockStyle.Right;
            tabControlRot.Visible = true;
        }
        private void toolStripBnTrans_Click(object sender, EventArgs e)
        {
            panel2.Visible = false;
            gbRGBFog.Visible = false;
            pnLighting.Visible = false;
            pnSca.Visible = false;
            pnRGB.Visible = false;
            tabControlRot.Visible = false;
            pnTrans.Dock = DockStyle.Right;
            pnTrans.Visible = true;
        }
        private void toolStripBnSca_Click(object sender, EventArgs e)
        {
            panel2.Visible = false;
            gbRGBFog.Visible = false;
            pnLighting.Visible = false;
            pnRGB.Visible = false;
            tabControlRot.Visible = false;
            pnTrans.Visible = false;
            pnSca.Dock = DockStyle.Right;
            pnSca.Visible = true;
        }
        private void toolStripBnLitg_Click(object sender, EventArgs e)
        {
            panel2.Visible = false;
            //lstLightSource[0].Enable = true;
            pnRGB.Visible = false;
            gbRGBFog.Visible = false;
            tabControlRot.Visible = false;
            pnTrans.Visible = false;
            pnSca.Visible = false;
            pnLighting.Dock = DockStyle.Right;
            pnLighting.Visible = true;
        }
        private void toolStripBnFog_Click(object sender, EventArgs e)
        {
            panel2.Visible = false;
            pnRGB.Visible = false;
            tabControlRot.Visible = false;
            pnTrans.Visible = false;
            pnSca.Visible = false;
            pnLighting.Visible = false;
            gbRGBFog.Dock = DockStyle.Right;
            gbRGBFog.Visible = true;
        }
        private void A_Click(object sender, EventArgs e)
        {
            pnRGB.Visible = false;
            tabControlRot.Visible = false;
            pnTrans.Visible = false;
            pnSca.Visible = false;
            pnLighting.Visible = false;
            gbRGBFog.Visible = false;
            panel2.Dock = DockStyle.Right;
            panel2.Visible = true;
        }

        #endregion

        #region Proceed panel RGB

        #region Proceed trackBar of RGBpanel

        private void trackBarRedRGB_Scroll(object sender, EventArgs e)
        {
            rbCustomRGB.Checked = true;
        }
        private void trackBarGreenRGB_Scroll(object sender, EventArgs e)
        {
            rbCustomRGB.Checked = true;
        }
        private void trackBarBlueRGB_Scroll(object sender, EventArgs e)
        {
            rbCustomRGB.Checked = true;
        }

        private void trackBarRedRGB_ValueChanged(object sender, EventArgs e)
        {
            if (m_strChoice == Choice.Background.ToString())
            {
                m_iRedBack = trackBarRedRGB.Value;
                SetBackgroundColor();
            }

            if (m_strChoice == Choice.Object.ToString())
            {
                m_iRedObject = trackBarRedRGB.Value;
                SetObjectColor();
            }

            numericUpDownRedRGB.Value = trackBarRedRGB.Value;
        }
        private void trackBarGreenRGB_ValueChanged(object sender, EventArgs e)
        {
            numericUpDownGreenRGB.Value = trackBarGreenRGB.Value;

            if (m_strChoice == Choice.Background.ToString())
            {
                m_iGreenBack = trackBarGreenRGB.Value;
                SetBackgroundColor();
            }

            if (m_strChoice == Choice.Object.ToString())
            {
                m_iGreenObject = trackBarGreenRGB.Value;
                SetObjectColor();
            }
        }
        private void trackBarBlueRGB_ValueChanged(object sender, EventArgs e)
        {

            numericUpDownBlueRGB.Value = trackBarBlueRGB.Value;

            if (m_strChoice == Choice.Background.ToString())
            {
                m_iBlueBack = trackBarBlueRGB.Value;
                SetBackgroundColor();
            }

            if (m_strChoice == Choice.Object.ToString())
            {
                m_iBlueObject = trackBarBlueRGB.Value;
                SetObjectColor();
            }
        }

        #endregion

        #region Proceed numericUpDown of RGBpanel

        private void numericUpDownRedRGB_ValueChanged(object sender, EventArgs e)
        {
            trackBarRedRGB.Value = (int)numericUpDownRedRGB.Value;
        }
        private void numericUpDownGreenRGB_ValueChanged(object sender, EventArgs e)
        {
            trackBarGreenRGB.Value = (int)numericUpDownGreenRGB.Value;
        }
        private void numericUpDownBlueRGB_ValueChanged(object sender, EventArgs e)
        {
            trackBarBlueRGB.Value = (int)numericUpDownBlueRGB.Value;
        }

        private void numericUpDownRedRGB_KeyUp(object sender, KeyEventArgs e)
        {
            trackBarRedRGB.Value = (int)numericUpDownRedRGB.Value;
        }
        private void numericUpDownGreenRGB_KeyUp(object sender, KeyEventArgs e)
        {
            trackBarGreenRGB.Value = (int)numericUpDownGreenRGB.Value;
        }
        private void numericUpDownBlueRGB_KeyUp(object sender, KeyEventArgs e)
        {
            trackBarBlueRGB.Value = (int)numericUpDownBlueRGB.Value;
        }

        private void numericUpDownRedRGB_Click(object sender, EventArgs e)
        {
            if (numericUpDownRedRGB.Value != 0)
            {
                rbCustomRGB.Checked = true;
            }
        }
        private void numericUpDownGreenRGB_Click(object sender, EventArgs e)
        {
            if (numericUpDownGreenRGB.Value != 0)
                rbCustomRGB.Checked = true;
        }
        private void numericUpDownBlueRGB_Click(object sender, EventArgs e)
        {
            if (numericUpDownBlueRGB.Value != 0)
                rbCustomRGB.Checked = true;
        }

        #endregion

        #region Proceed radioButton Black and White of RGBpanel.
        private void rbBlack_CheckedChanged(object sender, EventArgs e)
        {
            if (rbBlack.Checked == true)
            {
                trackBarRedRGB.Value = 0;
                trackBarGreenRGB.Value = 0;
                trackBarBlueRGB.Value = 0;
            }
        }
        private void rbWhite_CheckedChanged(object sender, EventArgs e)
        {
            if (rbWhite.Checked == true)
            {
                trackBarRedRGB.Value = 255;
                trackBarGreenRGB.Value = 255;
                trackBarBlueRGB.Value = 255;
            }
        }
        #endregion

        #region Proceed Button Cancel and Reset of RGBpanel.
        private void bnDoneRGB_Click(object sender, EventArgs e)
        {
            pnRGB.Visible = false;
        }
        private void bnCancelRGB_Click(object sender, EventArgs e)
        {
            pnRGB.Visible = false;

            if (rbObjectRGB.Enabled == true)
                rbWhite.Checked = true;
            rdBackgroundRGB.Checked = true;
            rbBlack.Checked = true;
        }
        private void bnResetRGB_Click(object sender, EventArgs e)
        {
            if (rbObjectRGB.Enabled == true)
                rbWhite.Checked = true;
            rdBackgroundRGB.Checked = true;
            rbBlack.Checked = true;
        }
        #endregion

        private void rbObjectRGB_CheckedChanged(object sender, EventArgs e)
        {
            if (rbObjectRGB.Checked == true)
            {
                m_strChoice = Choice.Object.ToString();

                trackBarRedRGB.Value = m_iRedObject;
                trackBarGreenRGB.Value = m_iGreenObject;
                trackBarBlueRGB.Value = m_iBlueObject;

                if (m_iRedObject == 255 && m_iGreenObject == 255 && m_iBlueObject == 255)
                    rbWhite.Checked = true;
            }
        }
        private void rdBackgroundRGB_CheckedChanged(object sender, EventArgs e)
        {
            if (rdBackgroundRGB.Checked == true)
            {
                m_strChoice = Choice.Background.ToString();

                trackBarRedRGB.Value = m_iRedBack;
                trackBarGreenRGB.Value = m_iGreenBack;
                trackBarBlueRGB.Value = m_iBlueBack;

                if (m_iRedBack == 0 && m_iGreenBack == 0 && m_iBlueBack == 0)
                    rbBlack.Checked = true;
            }
        }



        #endregion

        // Proceed Toolbar.
     
        // Xu Ly cho tab Rotate: tab Object.
        #region Xu ly cho Rot X
        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            trackBarRotXtabObject.Value = (int)numericUpDownRotXtabObject.Value;
        }
        private void numericUpDown1_KeyUp(object sender, KeyEventArgs e)
        {
            trackBarRotXtabObject.Value = (int)numericUpDownRotXtabObject.Value;
        }
        private void trackBarRotXtabObject_ValueChanged(object sender, EventArgs e)
        {
            // Set default cho cac combo Box ho tro.
            comboBoxLeftRot.Text = "Left";
            comboBoxRightRot.Text = "Right";
            comboBoxTopRot.Text = "Top";
            comboBoxBottomRot.Text = "Bottom";

            m_fRotX_Object = trackBarRotXtabObject.Value - m_itrackBarRotx;
            m_itrackBarRotx = trackBarRotXtabObject.Value;
            try
            {
                lstObj[0].Rotate(m_fRotX_Object, 1, 0, 0);
                simpleOpenGlControlPreViewcurrent.Draw();
            }
            catch (Exception _E) { ;}
            numericUpDownRotXtabObject.Value = trackBarRotXtabObject.Value;
        }

        #endregion
        #region Xu ly cho Rot Y
        private void numericUpDownRotY_KeyUp(object sender, KeyEventArgs e)
        {
            trackBarRotYtabObject.Value = (int)numericUpDownRotYtabObject.Value;
        }
        private void numericUpDownRotY_ValueChanged(object sender, EventArgs e)
        {
            trackBarRotYtabObject.Value = (int)numericUpDownRotYtabObject.Value;
        }
        private void trackBarRotYtabObject_ValueChanged(object sender, EventArgs e)
        {
            // Set default cho cac combo Box ho tro.
            comboBoxLeftRot.Text = "Left";
            comboBoxRightRot.Text = "Right";
            comboBoxTopRot.Text = "Top";
            comboBoxBottomRot.Text = "Bottom";

            m_fRotY_Object = trackBarRotYtabObject.Value - m_itrackBarRoty;
            m_itrackBarRoty = trackBarRotYtabObject.Value;
            try
            {
                lstObj[0].Rotate(m_fRotY_Object, 0, 1, 0);
                simpleOpenGlControlPreViewcurrent.Draw();
            }
            catch (Exception _E) { ;}
            numericUpDownRotYtabObject.Value = trackBarRotYtabObject.Value;
        }

        #endregion
        #region Xu ly cho Rot Z
        private void numericUpDownRotZ_KeyUp(object sender, KeyEventArgs e)
        {
            trackBarRotZtabObject.Value = (int)numericUpDownRotZtabObject.Value;
        }
        private void numericUpDownRotZ_ValueChanged(object sender, EventArgs e)
        {
            trackBarRotZtabObject.Value = (int)numericUpDownRotZtabObject.Value;
        }
        private void trackBarRotZtabObject_ValueChanged(object sender, EventArgs e)
        {
            // Set default cho cac combo Box ho tro.
            comboBoxLeftRot.Text = "Left";
            comboBoxRightRot.Text = "Right";
            comboBoxTopRot.Text = "Top";
            comboBoxBottomRot.Text = "Bottom";

            m_fRotZ_Object = trackBarRotZtabObject.Value - m_itrackBarRotz;
            m_itrackBarRotz = trackBarRotZtabObject.Value;
            try
            {
                lstObj[0].Rotate(m_fRotZ_Object, 0, 0, 1);
                simpleOpenGlControlPreViewcurrent.Draw();
            }
            
            catch (Exception _E) { ;}
            numericUpDownRotZtabObject.Value = trackBarRotZtabObject.Value;
        }

        #endregion

        //Xu ly cho comboBox Left.
        private void comboBoxLeftRot_TextChanged(object sender, EventArgs e)
        {
            // Set default cho cac comboBox con lai.
            comboBoxRightRot.Text = "Right";
            comboBoxTopRot.Text = "Top";
            comboBoxBottomRot.Text = "Bottom";

            switch (comboBoxLeftRot.Text)
            {
                case "Left 45":
                    trackBarRotXtabObject.Value = 0;
                    trackBarRotYtabObject.Value = -45;
                    trackBarRotZtabObject.Value = 0;
                    break;
                case "Left 90":
                    trackBarRotXtabObject.Value = 0;
                    trackBarRotYtabObject.Value = -90;
                    trackBarRotZtabObject.Value = 0;
                    break;
                case "Left 180":
                    trackBarRotXtabObject.Value = 0;
                    trackBarRotYtabObject.Value = -180;
                    trackBarRotZtabObject.Value = 0;
                    break;
                case "Left 360":
                    trackBarRotXtabObject.Value = 0;
                    trackBarRotYtabObject.Value = -360;
                    trackBarRotZtabObject.Value = 0;
                    break;
            }
        }
        private void comboBoxRightRot_TextChanged(object sender, EventArgs e)
        {
            // Set default cho cac comboBox con lai.
            comboBoxLeftRot.Text = "Left";
            comboBoxTopRot.Text = "Top";
            comboBoxBottomRot.Text = "Bottom";

            switch (comboBoxRightRot.Text)
            {
                case "Right 45":
                    trackBarRotXtabObject.Value = 0;
                    trackBarRotYtabObject.Value = 45;
                    trackBarRotZtabObject.Value = 0;
                    break;
                case "Right 90":
                    trackBarRotXtabObject.Value = 0;
                    trackBarRotYtabObject.Value = 90;
                    trackBarRotZtabObject.Value = 0;
                    break;
                case "Right 180":
                    trackBarRotXtabObject.Value = 0;
                    trackBarRotYtabObject.Value = 180;
                    trackBarRotZtabObject.Value = 0;
                    break;
                case "Right 360":
                    trackBarRotXtabObject.Value = 0;
                    trackBarRotYtabObject.Value = 360;
                    trackBarRotZtabObject.Value = 0;
                    break;
            }
        }
        private void comboBoxTopRot_TextChanged(object sender, EventArgs e)
        {
            // Set default cho cac comboBox con lai.
            comboBoxLeftRot.Text = "Left";
            comboBoxRightRot.Text = "Right";
            comboBoxBottomRot.Text = "Bottom";

            switch (comboBoxTopRot.Text)
            {
                case "Top 45":
                    trackBarRotXtabObject.Value = -45;
                    trackBarRotYtabObject.Value = 0;
                    trackBarRotZtabObject.Value = 0;
                    break;
                case "Top 90":
                    trackBarRotXtabObject.Value = -90;
                    trackBarRotYtabObject.Value = 0;
                    trackBarRotZtabObject.Value = 0;
                    break;
                case "Top 180":
                    trackBarRotXtabObject.Value = -180;
                    trackBarRotYtabObject.Value = 0;
                    trackBarRotZtabObject.Value = 0;
                    break;
                case "Top 360":
                    trackBarRotXtabObject.Value = -360;
                    trackBarRotYtabObject.Value = 0;
                    trackBarRotZtabObject.Value = 0;
                    break;
            }
        }
        private void comboBoxBottomRot_TextChanged(object sender, EventArgs e)
        {
            // Set default cho cac comboBox con lai.
            comboBoxLeftRot.Text = "Left";
            comboBoxRightRot.Text = "Right";
            comboBoxTopRot.Text = "Top";

            switch (comboBoxBottomRot.Text)
            {
                case "Bottom 45":
                    trackBarRotXtabObject.Value = 45;
                    trackBarRotYtabObject.Value = 0;
                    trackBarRotZtabObject.Value = 0;
                    break;
                case "Bottom 90":
                    trackBarRotXtabObject.Value = 90;
                    trackBarRotYtabObject.Value = 0;
                    trackBarRotZtabObject.Value = 0;
                    break;
                case "Bottom 180":
                    trackBarRotXtabObject.Value = 180;
                    trackBarRotYtabObject.Value = 0;
                    trackBarRotZtabObject.Value = 0;
                    break;
                case "Bottom 360":
                    trackBarRotXtabObject.Value = 360;
                    trackBarRotYtabObject.Value = 0;
                    trackBarRotZtabObject.Value = 0;
                    break;
            }
        }

        private void bnDonepnRot_Click(object sender, EventArgs e)
        {
            pnRotate.Visible = false;
        }

        private void bnCancelpnRot_Click(object sender, EventArgs e)
        {
            trackBarRotXtabObject.Value = 0;
            trackBarRotYtabObject.Value = 0;
            trackBarRotZtabObject.Value = 0;

            pnRotate.Visible = false;
        }

        // Xu ly cho button Reset.
        private void bnResetpnRot_Click(object sender, EventArgs e)
        {
            try
            {
                lstObj[0].Enable = false;
                trackBarRotXtabObject.Value = 0;
                trackBarRotYtabObject.Value = 0;
                trackBarRotZtabObject.Value = 0;
                lstObj[0] = new _Cone(30, 70, 100, 100);
                simpleOpenGlControlPreViewcurrent.Draw();
            }
            catch (Exception _E) { ;}
        }

        #region Xu ly tab Plane.
        #region Xu ly Rot X
        private void trackBarRotXtabPlane_ValueChanged(object sender, EventArgs e)
        {
            m_fRotX_Plane = trackBarRotXtabPlane.Value;
            simpleOpenGlControlPreViewcurrent.Draw();
            numericUpDownRotxtabPlane.Value = trackBarRotXtabPlane.Value;
        }
        private void trackBarRotXtabPlane_Scroll(object sender, EventArgs e)
        {
            rbCustomtabPlane.Checked = true;
        }
        private void numericUpDownRotxPlane_ValueChanged(object sender, EventArgs e)
        {
            trackBarRotXtabPlane.Value = (int)numericUpDownRotxtabPlane.Value;
        }
        private void numericUpDownRotxtabPlane_KeyUp(object sender, KeyEventArgs e)
        {
            trackBarRotXtabPlane.Value = (int)numericUpDownRotxtabPlane.Value;
        }
        private void numericUpDownRotxtabPlane_Click(object sender, EventArgs e)
        {
            if (numericUpDownRotxtabPlane.Value != 0)
                rbCustomtabPlane.Checked = true;
        }
        #endregion
        #region Xu ly Rot Y
        private void trackBarRotYtabPlane_ValueChanged(object sender, EventArgs e)
        {
            m_fRotY_Plane = trackBarRotYtabPlane.Value;// - m_itrackBarRotx;
            //m_itrackBarRotx = trackBarRotXtabObject.Value;
            simpleOpenGlControlPreViewcurrent.Draw();
            numericUpDownRotYtabPlane.Value = trackBarRotYtabPlane.Value;
        }
        private void trackBarRotYtabPlane_Scroll(object sender, EventArgs e)
        {
            rbCustomtabPlane.Checked = true;
        }
        private void numericUpDownRotYtabPlane_ValueChanged(object sender, EventArgs e)
        {
            trackBarRotYtabPlane.Value = (int)numericUpDownRotYtabPlane.Value;
        }

        private void numericUpDownRotYtabPlane_KeyUp(object sender, KeyEventArgs e)
        {
            trackBarRotYtabPlane.Value = (int)numericUpDownRotYtabPlane.Value;
        }
        private void numericUpDownRotYtabPlane_Click(object sender, EventArgs e)
        {
            if (numericUpDownRotYtabPlane.Value != 0)
                rbCustomtabPlane.Checked = true;
        }
        #endregion
        #region Xu ly Rot Z
        private void trackBarRotZtabPlane_ValueChanged(object sender, EventArgs e)
        {
            m_fRotZ_Plane = trackBarRotZtabPlane.Value;// - m_itrackBarRotx;
            //m_itrackBarRotx = trackBarRotXtabObject.Value;
            simpleOpenGlControlPreViewcurrent.Draw();
            numericUpDownRotZtabPlane.Value = trackBarRotZtabPlane.Value;
        }
        private void trackBarRotZtabPlane_Scroll(object sender, EventArgs e)
        {
            rbCustomtabPlane.Checked = true;
        }
        private void numericUpDownRotZtabPlane_ValueChanged(object sender, EventArgs e)
        {
            trackBarRotZtabPlane.Value = (int)numericUpDownRotZtabPlane.Value;
        }

        private void numericUpDownRotZtabPlane_KeyUp(object sender, KeyEventArgs e)
        {
            trackBarRotZtabPlane.Value = (int)numericUpDownRotZtabPlane.Value;
        }
        private void numericUpDownRotZtabPlane_Click(object sender, EventArgs e)
        {
            if (numericUpDownRotZtabPlane.Value != 0)
                rbCustomtabPlane.Checked = true;
        }
        #endregion

        #region Xu ly cac button cua tab Plane
        private void bnResettabPlane_Click(object sender, EventArgs e)
        {
            trackBarRotXtabPlane.Value = 0;
            trackBarRotYtabPlane.Value = 0;
            trackBarRotZtabPlane.Value = 0;
        }
        private void bnCanceltabPlane_Click(object sender, EventArgs e)
        {
            trackBarRotXtabPlane.Value = 0;
            trackBarRotYtabPlane.Value = 0;
            trackBarRotZtabPlane.Value = 0;

            tabControlRot.Visible = false;
        }
        private void bnDonetabPlane_Click(object sender, EventArgs e)
        {
            tabControlRot.Visible = false;
        }
        #endregion
        private void rbDefaulttabPlane_CheckedChanged(object sender, EventArgs e)
        {
            if (rbDefaulttabPlane.Checked == true)
            {
                trackBarRotXtabPlane.Value = 45;
                trackBarRotYtabPlane.Value = 0;
                trackBarRotZtabPlane.Value = 0;
            }
        }
        #endregion
        // User-defined function.
        #region User-defined function.

        #region Cac ham lien quan den simpleOpenGlControlPreViewcurrent
        private void SetView()
        {

            int h = simpleOpenGlControlPreViewcurrent.Height;
            int w = simpleOpenGlControlPreViewcurrent.Width;

            try
            {
                float fAspect = (float)w / (float)h;

                if (h == 0)
                    h = 1;
                // Set Viewport to window dimensions
                Gl.glViewport(0, 0, w, h);
                // Reset projection matrix stack
                Gl.glMatrixMode(Gl.GL_PROJECTION);
                Gl.glLoadIdentity();

                if (m_strView == View.Orthogonal.ToString())
                {
                    // Prevent a divide by zero
                    // Establish clipping volume (left, right, bottom, top, near, far)
                    if (w <= h)
                        Gl.glOrtho(-nRange, nRange, -nRange * h / w, nRange * h / w, -nRange, nRange);
                    //Glu.gluPerspective(60.0f, w/h, 1.0, 400.0);
                    else
                        Gl.glOrtho(-nRange * w / h, nRange * w / h, -nRange, nRange, -nRange, nRange);
                }

                else if (m_strView == View.Perspective.ToString())
                {
                    // Produce the perspective projection
                    //Glu.gluPerspective(60.0f, fAspect, 1.0, 400.0);

                    Glu.gluPerspective(60.0f, fAspect, 1.0, 400.0);
                    Gl.glTranslatef(0.0f, 0.0f, -300.0f);
                }

                // Reset Model view matrix stack   
                Gl.glMatrixMode(Gl.GL_MODELVIEW);
                Gl.glLoadIdentity();
            }
            catch (Exception _e) { ;}
            
        }
        private void SetupRC()
        {
            Gl.glFrontFace(Gl.GL_CCW);		// Counter clock-wise polygons face out
            Gl.glCullFace(Gl.GL_BACK);
            Gl.glEnable(Gl.GL_CULL_FACE); // Do not calculate inside of jet
            // Enable lighting
            //            Gl.glEnable(Gl.GL_LIGHTING);

            float[] ambientLight = new float[4] { 0.2f, 0.2f, 0.2f, 1 };
            Gl.glLightModelfv(Gl.GL_LIGHT_MODEL_AMBIENT, ambientLight);
            //            Gl.glLightModeli(Gl.GL_LIGHT_MODEL_LOCAL_VIEWER, Gl.GL_TRUE);
            // Enable color tracking
                        Gl.glEnable(Gl.GL_COLOR_MATERIAL);

            // Light blue background
            Gl.glClearColor(0.0f, 0.0f, 0.0f, 1.0f);
            // Rescale normals to unit length
            Gl.glShadeModel(Gl.GL_SMOOTH);
            Gl.glEnable(Gl.GL_NORMALIZE);
        }

        #endregion
        private void SetBackgroundColor()
        {
            Gl.glClearColor(m_iRedBack / 255.0f, m_iGreenBack / 255.0f, m_iBlueBack / 255.0f, m_iAlphaBack / 255.0f);
            simpleOpenGlControlPreViewcurrent.Draw();
        }
        private void SetObjectColor()
        {
            try
            {
                lstObj[0].Red = m_iRedObject;
                lstObj[0].Green = m_iGreenObject;
                lstObj[0].Blue = m_iBlueObject;
                lstObj[0].Alpha = m_iAlphaObject;
                //obj[0].Color = new float[4] { 0,0,0,0};
                simpleOpenGlControlPreViewcurrent.Draw();
            }
            catch (Exception _E) { ;}
        }
        private void SetLocationsimpleOpenGl(int x, int y)
        {
            Point tempPoint = simpleOpenGlControlPreViewcurrent.Location;
            tempPoint.X = x;
            tempPoint.Y = y;
            simpleOpenGlControlPreViewcurrent.Location = tempPoint;
        }
        private void SetSizesimpleOpenGL(int iWidth, int iHeight)
        {
            Size tempSize = simpleOpenGlControlPreViewcurrent.Size;
            tempSize.Width = iWidth;
            tempSize.Height = iHeight;
            simpleOpenGlControlPreViewcurrent.Size = tempSize;
        }
        #endregion


        #region Xu ly panel Translate.
        #region Xu ly Translate X
        private void trackBarTransX_pnTrans_ValueChanged(object sender, EventArgs e)
        {
            m_fTransX = trackBarTransX_pnTrans.Value - m_itrackBarTransX;
            m_itrackBarTransX = trackBarTransX_pnTrans.Value;
            try
            {
                lstObj[0].Translate(m_fTransX, 0, 0);
                simpleOpenGlControlPreViewcurrent.Draw();
            }
            
            catch (Exception _E) { ;}
            numericUpDownTransX_pnTrans.Value = trackBarTransX_pnTrans.Value;
        }
        private void trackBarTransX_pnTrans_Scroll(object sender, EventArgs e)
        {
            rbCustomTrans.Checked = true;
        }
        private void numericUpDownTransX_pnTrans_ValueChanged(object sender, EventArgs e)
        {
            trackBarTransX_pnTrans.Value = (int)numericUpDownTransX_pnTrans.Value;
        }

        private void numericUpDownTransX_pnTrans_KeyUp(object sender, KeyEventArgs e)
        {
            trackBarTransX_pnTrans.Value = (int)numericUpDownTransX_pnTrans.Value;
        }
        private void numericUpDownTransX_pnTrans_Click(object sender, EventArgs e)
        {
            if (numericUpDownTransX_pnTrans.Value != 0)
                rbCustomTrans.Checked = true;
        }
        #endregion
        #region Xu Ly Tranlate Y
        private void trackBarTransY_pnTrans_ValueChanged(object sender, EventArgs e)
        {
            m_fTransY = trackBarTransY_pnTrans.Value - m_itrackBarTransY;
            m_itrackBarTransY = trackBarTransY_pnTrans.Value;
            try
            {
                lstObj[0].Translate(0, m_fTransY, 0);
                simpleOpenGlControlPreViewcurrent.Draw();
            }
            catch (Exception _E) { ;}
            numericUpDownTransY_pnTrans.Value = trackBarTransY_pnTrans.Value;
        }
        private void trackBarTransY_pnTrans_Scroll(object sender, EventArgs e)
        {
            rbCustomTrans.Checked = true;
        }
        private void numericUpDownTransY_pnTrans_ValueChanged(object sender, EventArgs e)
        {
            trackBarTransY_pnTrans.Value = (int)numericUpDownTransY_pnTrans.Value;
        }
        private void numericUpDownTransY_pnTrans_Click(object sender, EventArgs e)
        {
            if (numericUpDownTransY_pnTrans.Value != 0)
                rbCustomTrans.Checked = true;
        }
        private void numericUpDownTransY_pnTrans_KeyUp(object sender, KeyEventArgs e)
        {
            trackBarTransY_pnTrans.Value = (int)numericUpDownTransY_pnTrans.Value;
        }
        #endregion
        #region Xu Ly Translate Z
        private void trackBarTransZ_pnTrans_ValueChanged(object sender, EventArgs e)
        {
            m_fTransZ = trackBarTransZ_pnTrans.Value - m_itrackBarTransZ;
            m_itrackBarTransZ = trackBarTransZ_pnTrans.Value;
            try
            {
                lstObj[0].Translate(0, 0, m_fTransZ);
                simpleOpenGlControlPreViewcurrent.Draw();
            }
            catch (Exception _E) { ;}
            
            numericUpDownTransZ_pnTrans.Value = trackBarTransZ_pnTrans.Value;
        }
        private void trackBarTransZ_pnTrans_Scroll(object sender, EventArgs e)
        {
            rbCustomTrans.Checked = true;
        }
        private void numericUpDownTransZ_pnTrans_ValueChanged(object sender, EventArgs e)
        {
            trackBarTransZ_pnTrans.Value = (int)numericUpDownTransZ_pnTrans.Value;
        }
        private void numericUpDownTransZ_pnTrans_Click(object sender, EventArgs e)
        {
            if (numericUpDownTransZ_pnTrans.Value != 0)
                rbCustomTrans.Checked = true;
        }

        private void numericUpDownTransZ_pnTrans_KeyUp(object sender, KeyEventArgs e)
        {
            trackBarTransZ_pnTrans.Value = (int)numericUpDownTransZ_pnTrans.Value;
        }
        #endregion
        #region Xu Ly button cua panel Translate.
        private void bnResetTrans_Click(object sender, EventArgs e)
        {
            try
            {
                lstObj[0].Enable = false;
                trackBarTransX_pnTrans.Value = 0;
                trackBarTransY_pnTrans.Value = 0;
                trackBarTransZ_pnTrans.Value = 0;
                lstObj[0] = new _Cone(30, 70, 100, 100);
                simpleOpenGlControlPreViewcurrent.Draw();
            }
            catch (Exception _E) { ;}
            
        }
        private void bnDoneTrans_Click(object sender, EventArgs e)
        {
            pnTrans.Visible = false;
        }
        private void bnCancelTrans_Click(object sender, EventArgs e)
        {
            try
            {
                lstObj[0].Enable = false;
                trackBarTransX_pnTrans.Value = 0;
                trackBarTransY_pnTrans.Value = 0;
                trackBarTransZ_pnTrans.Value = 0;
                lstObj[0] = new _Cone(30, 70, 100, 100);
                simpleOpenGlControlPreViewcurrent.Draw();
            }
            catch (Exception _E) { ;}
            

            pnTrans.Visible = false;
        }
        #endregion
        private void rdRightTrans_CheckedChanged(object sender, EventArgs e)
        {
            if (rdRightTrans.Checked == true)
            {
                trackBarTransX_pnTrans.Value = 50;
                trackBarTransY_pnTrans.Value = 0;
                trackBarTransY_pnTrans.Value = 0;
            }
        }

        private void rdTopTrans_CheckedChanged(object sender, EventArgs e)
        {
            if (rdTopTrans.Checked == true)
            {
                trackBarTransX_pnTrans.Value = 0;
                trackBarTransY_pnTrans.Value = 50;
                trackBarTransZ_pnTrans.Value = 0;
            }
        }

        private void rbBottomTrans_CheckedChanged(object sender, EventArgs e)
        {
            if (rbBottomTrans.Checked == true)
            {
                trackBarTransX_pnTrans.Value = 0;
                trackBarTransY_pnTrans.Value = -50;
                trackBarTransZ_pnTrans.Value = 0;
            }
        }

        private void rbLeftTrans_CheckedChanged(object sender, EventArgs e)
        {
            if(rbLeftTrans.Checked == true)
            {
                trackBarTransX_pnTrans.Value = -50;
                trackBarTransY_pnTrans.Value = 0;
                trackBarTransY_pnTrans.Value = 0;
            }
        }
        #endregion
        #region Xu Ly panel Scale
        #region Xu Ly Scale X
        private void trackBarScaX_pnScale_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                m_fScaX = (float)trackBarScaX_pnScale.Value / (float)m_itrackBarScaX;
                m_itrackBarScaX = trackBarScaX_pnScale.Value;
                if (rbShrink_pnScale.Checked == true)
                    lstObj[0].Scale(1.0f / m_fScaX, 1, 1);
                if (rbStretch_pnScale.Checked == true)
                    lstObj[0].Scale(m_fScaX, 1, 1);
                simpleOpenGlControlPreViewcurrent.Draw();
                numericUpDownScaX_pnScale.Value = trackBarScaX_pnScale.Value;
            }
            catch (Exception _E) { ;}
            
        }
        private void numericUpDownScaX_pnScale_ValueChanged(object sender, EventArgs e)
        {
            trackBarScaX_pnScale.Value = (int)numericUpDownScaX_pnScale.Value;
        }
        private void numericUpDownScaX_pnScale_KeyUp(object sender, KeyEventArgs e)
        {
            trackBarScaX_pnScale.Value = (int)numericUpDownScaX_pnScale.Value;
        }
        #endregion
        #region Xu Ly Scale Y
        private void trackBarScaY_pnScale_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                m_fScaY = (float)trackBarScaY_pnScale.Value / (float)m_itrackBarScaY;
                m_itrackBarScaY = trackBarScaY_pnScale.Value;
                if (rbShrink_pnScale.Checked == true)
                    lstObj[0].Scale(1.0f, 1.0f / m_fScaY, 1.0f);
                if (rbStretch_pnScale.Checked == true)
                    lstObj[0].Scale(1.0f, m_fScaY, 1.0f);
                simpleOpenGlControlPreViewcurrent.Draw();
                numericUpDownScaY_pnScale.Value = trackBarScaY_pnScale.Value;
            }
            catch (Exception _e) { ;}
        }
        private void numericUpDownScaY_pnScale_KeyUp(object sender, KeyEventArgs e)
        {
            trackBarScaY_pnScale.Value = (int)numericUpDownScaY_pnScale.Value;
        }
        private void numericUpDownScaY_pnScale_ValueChanged(object sender, EventArgs e)
        {
            trackBarScaY_pnScale.Value = (int)numericUpDownScaY_pnScale.Value;
        }
        #endregion
        #region Xu Ly Scale Z
        private void trackBarScaZ_pnScale_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                m_fScaZ = (float)trackBarScaZ_pnScale.Value / (float)m_itrackBarScaZ;
                m_itrackBarScaZ = trackBarScaZ_pnScale.Value;
                if (rbShrink_pnScale.Checked == true)
                    lstObj[0].Scale(1.0f, 1.0f, 1.0f / m_fScaZ);
                if (rbStretch_pnScale.Checked == true)
                    lstObj[0].Scale(1.0f, 1.0f, m_fScaZ);
                simpleOpenGlControlPreViewcurrent.Draw();
                numericUpDownScaZ_pnScale.Value = trackBarScaZ_pnScale.Value;
            }
            catch (Exception _e) { ;}
            
        }
        private void numericUpDownScaZ_pnScale_ValueChanged(object sender, EventArgs e)
        {
            trackBarScaZ_pnScale.Value = (int)numericUpDownScaZ_pnScale.Value;
        }
        private void numericUpDownScaZ_pnScale_KeyUp(object sender, KeyEventArgs e)
        {
            trackBarScaZ_pnScale.Value = (int)numericUpDownScaZ_pnScale.Value;
        }
        #endregion                    

        private void numericUpDown5_ValueChanged(object sender, EventArgs e)
        {
            m_fLightingX = (float)numericUpDown5.Value;
            lstLightSource[0].LightPos = new float[3] { m_fLightingX, m_fLightingY, m_fLightingZ};
            lstShadow[0].CalculatorMatrix(lstLightSource[0]);
            simpleOpenGlControlPreViewcurrent.Draw();
        }
        private void numericUpDown6_ValueChanged(object sender, EventArgs e)
        {
            m_fLightingY = (float)numericUpDown6.Value;
            lstLightSource[0].LightPos = new float[3] { m_fLightingX, m_fLightingY, m_fLightingZ};
            lstShadow[0].CalculatorMatrix(lstLightSource[0]);
            simpleOpenGlControlPreViewcurrent.Draw();
        }

        private void numericUpDown7_ValueChanged(object sender, EventArgs e)
        {
            m_fLightingZ = (float)numericUpDown7.Value;
            lstLightSource[0].LightPos = new float[3] { m_fLightingX, m_fLightingY, m_fLightingZ };
            lstShadow[0].CalculatorMatrix(lstLightSource[0]);
            simpleOpenGlControlPreViewcurrent.Draw();
        }
        #endregion
        /*
        private void numericUpDown1_ValueChanged_1(object sender, EventArgs e)
        {
            lstLightSource[0].Red = (int)numericUpDown1.Value;
            simpleOpenGlControlPreViewcurrent.Draw();
        }
         */

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            lstLightSource[0].Green = (int)numericUpDown2.Value;
            simpleOpenGlControlPreViewcurrent.Draw();
        }

        private void numericUpDown3_ValueChanged(object sender, EventArgs e)
        {
            lstLightSource[0].Blue = (int)numericUpDown3.Value;
            simpleOpenGlControlPreViewcurrent.Draw();
        }

        private void numericUpDown1_KeyUp_1(object sender, KeyEventArgs e)
        {
            lstLightSource[0].Red = (int)numericUpDown1.Value;
            simpleOpenGlControlPreViewcurrent.Draw();
        }

        private void cbShowLight_pnLighting_CheckedChanged(object sender, EventArgs e)
        {
            lstLightSource[0].Enable = cbShowLight_pnLighting.Checked;
            lstShadow[0].Enable = cbShowLight_pnLighting.Checked; 
            if (lstLightSource[0].Enable)
                Gl.glEnable(Gl.GL_LIGHTING);
            else
                Gl.glDisable(Gl.GL_LIGHTING);
            simpleOpenGlControlPreViewcurrent.Draw();
        }

        private void toolStripBnTex_Click(object sender, EventArgs e)
        {
            texture.Enable = !texture.Enable;
            texture.Apply();
            try
            {
                lstObj[0].EnableTexture = !lstObj[0].EnableTexture;
                simpleOpenGlControlPreViewcurrent.Draw();
            }
            catch (Exception _e)
            {
                ;
            }
        }

        private void cbFogEffect_gbRGB_CheckedChanged(object sender, EventArgs e)
        {
            fog.Enable = cbFogEffect_gbRGB.Checked;
            simpleOpenGlControlPreViewcurrent.Draw();
        }

        private void trackBarRed_gpRGB_ValueChanged(object sender, EventArgs e)
        {

        }

        private void numericUpDown13_ValueChanged(object sender, EventArgs e)
        {

        }

        private void trackBarRed_gpRGB_Scroll(object sender, EventArgs e)
        {
            m_iRedFog = trackBarRed_gpRGB.Value;
            fog.Color = new int[4] { m_iRedFog, m_iGreenFog, m_iBlueFog, 1 };
            simpleOpenGlControlPreViewcurrent.Draw();
        }

        private void trackBar3_Scroll(object sender, EventArgs e)
        {
            m_iGreenFog = trackBarRed_gpRGB.Value;
            fog.Color = new int[4] { m_iRedFog, m_iGreenFog, m_iBlueFog, 1 };
            simpleOpenGlControlPreViewcurrent.Draw();
        }

        private void trackBar4_Scroll(object sender, EventArgs e)
        {
            m_iBlueFog = trackBarRed_gpRGB.Value;
            fog.Color = new int[4] { m_iRedFog, m_iGreenFog, m_iBlueFog, 1 };
            simpleOpenGlControlPreViewcurrent.Draw();
        }

        private void trackBar1_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                m_fRotany_Object = trackBar1.Value - m_itrackBarRotany;
                m_itrackBarRotany = trackBar1.Value;
                lstObj[0].Rotate(m_fRotany_Object, lstVector[0].pBegin, lstVector[0].pEnd);
                simpleOpenGlControlPreViewcurrent.Draw();
                numericUpDown4.Value = trackBar1.Value;
            }
            catch (Exception _e) { ;}
        }

        private void numericUpDown4_ValueChanged(object sender, EventArgs e)
        {

        }

        private void numericUpDown4_KeyUp(object sender, KeyEventArgs e)
        {

        }

        private void trackBarRotXtabObject_Scroll(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            lstVector[0].Enable = checkBox1.Checked;
            simpleOpenGlControlPreViewcurrent.Draw();
        }

        private void bnZoomInSca_Click(object sender, EventArgs e)
        {
            zoom *= 2;
            simpleOpenGlControlPreViewcurrent.Draw();
        }

        private void bnZoomOutSca_Click(object sender, EventArgs e)
        {
            zoom /= 2;
            simpleOpenGlControlPreViewcurrent.Draw();
        }

        private void pnLighting_Paint(object sender, PaintEventArgs e)
        {

        }

        private void bnOx_Click(object sender, EventArgs e)
        {
            try
            {
                lstObj[0].Axisymmetric(new float[] { 0, 0, 0 }, new float[] { 1, 0, 0 });
                simpleOpenGlControlPreViewcurrent.Draw();
            }
            catch (Exception _e)
            {
                ;
            }
        }

        private void bnVector_Click(object sender, EventArgs e)
        {
            try
            {
                lstObj[0].Axisymmetric(lstVector[0].pBegin, lstVector[0].pEnd);
                simpleOpenGlControlPreViewcurrent.Draw();
            }
            
            catch (Exception _e)
            {
                ;
            }
        }

        private void bnOy_Click(object sender, EventArgs e)
        {
            try
            {


                lstObj[0].Axisymmetric(new float[] { 0, 0, 0 }, new float[] { 0, 1, 0 });
                simpleOpenGlControlPreViewcurrent.Draw();
            }
            catch (Exception _e)
            {
                ;
            }
        }

        private void bnOz_Click(object sender, EventArgs e)
        {
            try
            {
                lstObj[0].Axisymmetric(new float[] { 0, 0, 0 }, new float[] { 0, 0, 1 });
                simpleOpenGlControlPreViewcurrent.Draw();
            }
            catch (Exception _e)
            {
                ;
            }
        }

        private void cbShowVector_CheckedChanged(object sender, EventArgs e)
        {
            lstVector[0].Enable = cbShowVector.Checked;
            simpleOpenGlControlPreViewcurrent.Draw();
        }

        private void trackBarScaX_pnScale_Scroll(object sender, EventArgs e)
        {

        }

        

        
        #region Xu Ly panel Lighting.

        #endregion





    }
}