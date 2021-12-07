import React, {Component, useState} from 'react';
import {
    CForm,
    CFormSelect,
    CButton,
    CFormLabel,
    CFormInput,
    CRow,
    CCol,
    CContainer,
    CCard,
    CCardImage,
    CModal,
    CModalHeader,
    CModalTitle,
    CModalBody,
    CModalFooter
} from '@coreui/react';
import {Row} from "reactstrap";

const cardImageCss = {
    "padding": "2px"
}

const cardCss = {
    'width': '9rem',
    'flex-direction': 'row'
}

export class TileGenerator extends Component {
    static displayName = TileGenerator.name;

    constructor(props) {
        super(props);
        this.state = {
            modalVisible: false,
            totalRendered: 10,
            file: "LC08_L2SP_144052_20211028_20211104_02_T1"
        };

        this.getDataSets();
    }

    componentDidMount() {

    }

    componentDidUpdate(prevProps, prevState, snapshot) {

    }

    renderControls() {
        // TODO: Generate years it programmatically
        return <div>
            <CForm>
                <CContainer>
                    <CRow>
                        <CCol size="sm">
                            <CButton color="primary" onClick={() => this.generateTiles()}>Generate Tiles</CButton>
                        </CCol>
                    </CRow>
                    <CRow>
                        <CCol size="sm">
                            {JSON.stringify(this.state.pendingFiles)}
                        </CCol>
                    </CRow>
                </CContainer>
            </CForm>

        </div>;
    }

    async generateTiles() {
        try {
            const response = await fetch(`/api/landsattilegenerator/generate-tiles`);
            const data = await response.json();
            this.setState({pendingFiles: data, loading: false});
        } catch (ex) {
            console.log(ex)
        }
    }

    async getDataSets() {
        try {
            // const response = await fetch(`/api/landsattilegenerator/get-datasets`);
            setTimeout(() => {
                const data = ["LC08_L2SP_143054_20190101_20200830_02_T1","LC08_L2SP_143054_20190117_20200830_02_T1","LC08_L2SP_143054_20190202_20200829_02_T1","LC08_L2SP_143054_20190218_20200829_02_T1","LC08_L2SP_143054_20190306_20200829_02_T1","LC08_L2SP_143054_20190322_20200829_02_T1","LC08_L2SP_143054_20190407_20200829_02_T1","LC08_L2SP_143054_20190423_20200828_02_T1","LC08_L2SP_143054_20190509_20200829_02_T1","LC08_L2SP_143054_20190525_20200828_02_T1","LC08_L2SP_143054_20190610_20200828_02_T1","LC08_L2SP_143054_20190626_20200827_02_T1","LC08_L2SP_143054_20190712_20200827_02_T1","LC08_L2SP_143054_20190728_20200827_02_T1","LC08_L2SP_143054_20190813_20200827_02_T1","LC08_L2SP_143054_20190829_20200826_02_T1","LC08_L2SP_143054_20190914_20200826_02_T1","LC08_L2SP_143054_20190930_20200825_02_T1","LC08_L2SP_143054_20191016_20200825_02_T1","LC08_L2SP_143054_20191101_20200825_02_T1","LC08_L2SP_143054_20191117_20200825_02_T1","LC08_L2SP_143054_20191203_20200825_02_T2","LC08_L2SP_143054_20191219_20200824_02_T1","LC08_L2SP_143054_20191219_20201023_02_T1","LC08_L2SP_143054_20200104_20200823_02_T1","LC08_L2SP_143054_20200120_20200823_02_T1","LC08_L2SP_143054_20200205_20200823_02_T1","LC08_L2SP_143054_20200221_20200822_02_T1","LC08_L2SP_143054_20200308_20200822_02_T1","LC08_L2SP_143054_20200324_20200822_02_T1","LC08_L2SP_143054_20200409_20200822_02_T1","LC08_L2SP_143054_20200425_20200822_02_T1","LC08_L2SP_143054_20200511_20200820_02_T1","LC08_L2SP_143054_20200527_20200820_02_T1","LC08_L2SP_143054_20200612_20200824_02_T1","LC08_L2SP_143054_20200628_20200824_02_T1","LC08_L2SP_143054_20200714_20200912_02_T1","LC08_L2SP_143054_20200730_20200908_02_T1","LC08_L2SP_143054_20200815_20200919_02_T1","LC08_L2SP_143054_20200831_20200906_02_T1","LC08_L2SP_143054_20200916_20200920_02_T1","LC08_L2SP_143054_20201002_20201007_02_T1","LC08_L2SP_143054_20201018_20201105_02_T1","LC08_L2SP_143054_20201119_20210315_02_T1","LC08_L2SP_143054_20201205_20210313_02_T1","LC08_L2SP_143054_20201221_20210310_02_T1","LC08_L2SP_143054_20210106_20210309_02_T1","LC08_L2SP_143054_20210122_20210307_02_T1","LC08_L2SP_143054_20210207_20210302_02_T1","LC08_L2SP_143054_20210223_20210303_02_T1","LC08_L2SP_143054_20210311_20210317_02_T1","LC08_L2SP_143054_20210327_20210402_02_T1","LC08_L2SP_143054_20210412_20210416_02_T1","LC08_L2SP_143054_20210428_20210507_02_T1","LC08_L2SP_143054_20210514_20210525_02_T1","LC08_L2SP_143054_20210530_20210608_02_T1","LC08_L2SP_143054_20210615_20210622_02_T1","LC08_L2SP_143054_20210701_20210708_02_T1","LC08_L2SP_143054_20210717_20210729_02_T1","LC08_L2SP_143054_20210802_20210810_02_T1",
                    "LC08_L2SP_143054_20210818_20210827_02_T1","LC08_L2SP_143054_20210903_20210910_02_T1","LC08_L2SP_143054_20210919_20210925_02_T1","LC08_L2SP_143054_20211005_20211013_02_T1","LC08_L2SP_143054_20211021_20211026_02_T1","LC08_L2SP_143054_20211106_20211117_02_T1","LC08_L2SP_143054_20211122_20211130_02_T1"];
                this.setState({datasets: data});
            }, 500);

        } catch (ex) {
            console.log(ex)
        }
    }

    renderBands() {
        if (!this.state.datasets) {
            return <div>Loading DataSets</div>;
        }
        const cols = []
        for (var i = 0; i < this.state.totalRendered; i++) {
            const file = this.state.datasets[i];

            cols.push(
                <CRow>
                    <CCol xs={4}>
                        {file}
                    </CCol>
                    <CCol>
                        <CCard style={cardCss}>
                            {/*<CCardImage style={cardImageCss} orientation="top" src={`https://52.11.253.156/landsat-tile/${this.state.file}_SR_B1.png`}/>*/}
                            <CCardImage style={cardImageCss} onClick={(e) => this.onImageClicked(e)} orientation="top"
                                        src={`https://52.11.253.156/landsat-tile/${file.replace("_T1", "")}_mndwi.png`}/>
                            <CCardImage style={cardImageCss} onClick={(e) => this.onImageClicked(e)} orientation="top"
                                        src={`https://52.11.253.156/landsat-tile/${file.replace("_T1", "")}_ndwi.png`}/>
                            <CCardImage style={cardImageCss} onClick={(e) => this.onImageClicked(e)} orientation="top"
                                        src={`https://52.11.253.156/landsat-tile/${file}_SR_B2.png`}/>
                            <CCardImage style={cardImageCss} onClick={(e) => this.onImageClicked(e)} orientation="top"
                                        src={`https://52.11.253.156/landsat-tile/${file}_SR_B3.png`}/>
                            <CCardImage style={cardImageCss} onClick={(e) => this.onImageClicked(e)} orientation="top"
                                        src={`https://52.11.253.156/landsat-tile/${file}_SR_B4.png`}/>
                            <CCardImage style={cardImageCss} onClick={(e) => this.onImageClicked(e)} orientation="top"
                                        src={`https://52.11.253.156/landsat-tile/${file}_SR_B5.png`}/>
                            <CCardImage style={cardImageCss} onClick={(e) => this.onImageClicked(e)} orientation="top"
                                        src={`https://52.11.253.156/landsat-tile/${file}_SR_B6.png`}/>
                            <CCardImage style={cardImageCss} onClick={(e) => this.onImageClicked(e)} orientation="top"
                                        src={`https://52.11.253.156/landsat-tile/${file}_SR_B7.png`}/>
                            {/*<CCardImage style={cardImageCss} orientation="top" src={`https://52.11.253.156/landsat-tile/${this.state.file}_ST_B10.png`}/>*/}
                        </CCard>
                    </CCol>

                </CRow>
            )
        }
        return <CRow>
            {cols}
        </CRow>
    }

    onImageClicked(e) {
        this.setState({
            selectedImage: e.target.src
        })
        this.setModalVisible(true);
    }

    setModalVisible(value) {
        this.setState({
            modalVisible: value
        });
    }

    renderModal() {
        const visible = this.state.modalVisible;

        return <CModal size="xl" visible={visible} onClose={() => this.setModalVisible(false)}>
            <CModalHeader onClose={() => this.setModalVisible(false)}>
                <CModalTitle>{this.state.selectedImage}</CModalTitle>
            </CModalHeader>
            <CModalBody>
                <CCard>
                    <CCardImage src={this.state.selectedImage}/>
                </CCard>
            </CModalBody>
            <CModalFooter>
                <CButton color="secondary" onClick={() => this.setModalVisible(false)}>
                    Close
                </CButton>
            </CModalFooter>
        </CModal>
    }
    
    renderFooterControls() {
        return <CRow>
            <CCol size="sm">
                <CButton color="primary" onClick={() => this.renderMoreClicked()}>Render More</CButton>
            </CCol>
        </CRow>
    }
    
    renderMoreClicked() {
        this.setState({
            totalRendered: this.state.totalRendered + 5
        })
    }

    render() {
        let controls = this.renderControls();
        let bands = this.renderBands();
        let modal = this.renderModal();
        let footerControls = this.renderFooterControls();

        return (
            <div>
                {modal}
                {controls}
                <hr/>
                {bands}
                <hr/>
                {footerControls}
            </div>
        );
    }
}
