import React, { useState, useEffect } from 'react';
import AdminNavbar from '../Admin Navbar/AdminNavbar';
import './AdminGallery.css';
import Modal from '@mui/material/Modal';
import Box from '@mui/material/Box';
import Typography from '@mui/material/Typography';
import IconButton from '@mui/material/IconButton';
import CloseIcon from '@mui/icons-material/Close';
import axios from 'axios';

const AdminGallery = () => {
  const [isModalOpen, setIsModalOpen] = useState(false);
  const [selectedFile, setSelectedFile] = useState(null);
  const [galleries, setGalleries] = useState([]);

  useEffect(() => {
    fetchGalleries();
  }, []);

  const handleOpenModal = () => {
    setIsModalOpen(true);
  };

  const handleCloseModal = () => {
    setIsModalOpen(false);
    setSelectedFile(null);
  };

  const handleFileInputChange = (e) => {
    setSelectedFile(e.target.files[0]);
  };

  const handleSubmit = async () => {
    if (selectedFile) {
      console.log("Selected file before submission:", selectedFile);
      const formData = new FormData();
      formData.append('imageUrl', selectedFile);

      try {
        await axios.post('https://localhost:7204/api/Galleries', formData);
        fetchGalleries();
        handleCloseModal();
      } catch (error) {
        console.error('Error adding image:', error);
      }
    }
  };

  const fetchGalleries = async () => {
    try {
      const response = await axios.get('https://localhost:7204/api/Galleries');
      setGalleries(response.data);
    } catch (error) {
      console.error('Error fetching galleries:', error);
    }
  };

  return (
    <div className="adminGalleryContainer">
      <AdminNavbar />
      <div className='separateButton'>
        <div>
          <button onClick={handleOpenModal} className="addImageButton">
            Add Image
          </button>
        </div>
        {/* MUI Modal */}
        <Modal
          open={isModalOpen}
          onClose={handleCloseModal}
          aria-labelledby="modal-title"
          aria-describedby="modal-description"
        >
          <Box sx={{ position: 'absolute', top: '50%', left: '50%', transform: 'translate(-50%, -50%)' }}>
            <Box className="modal-content">
              <IconButton
                edge="end"
                color="inherit"
                onClick={handleCloseModal}
                aria-label="close"
                sx={{ position: 'absolute', top: 8, right: 8 }}
              >
                <CloseIcon />
              </IconButton>
              <Typography id="modal-title" variant="h4">
                Choose Image
              </Typography>
              <input type="file" className='inputFile' onChange={handleFileInputChange} />
              <button onClick={handleSubmit} className="submitButton">
                Submit
              </button>
            </Box>
          </Box>
        </Modal>
        <div>
          <h1 className='galleryHeading'>Our Happy Travelers</h1>
          <div id="flexbox" className="galleryFlexbox">
            {galleries.map((gallery, index) => (
              <div key={index} className="column">
                <img src={gallery.imageUrl} alt={`Gallery ${index}`} width="100%" />
              </div>
            ))}
          </div>
        </div>
      </div>
    </div>
  );
};

export default AdminGallery;
