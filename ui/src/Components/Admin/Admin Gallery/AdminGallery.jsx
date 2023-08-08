import React, { useState } from 'react';
import AdminNavbar from '../Admin Navbar/AdminNavbar';
import './AdminGallery.css';
import Modal from '@mui/material/Modal';
import Box from '@mui/material/Box';
import Typography from '@mui/material/Typography';
import IconButton from '@mui/material/IconButton';
import CloseIcon from '@mui/icons-material/Close';

const AdminGallery = () => {
  const [isModalOpen, setIsModalOpen] = useState(false);

  // Function to handle modal open event
  const handleOpenModal = () => {
    setIsModalOpen(true);
  };

  // Function to handle modal close event
  const handleCloseModal = () => {
    setIsModalOpen(false);
  };

  // Function to handle file input change
  const handleFileInputChange = (e) => {
    // Handle the selected image file here (e.target.files[0])
    console.log('Selected file:', e.target.files[0]);
    // Close the modal after selecting the image
    handleCloseModal();
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
            </Box>
          </Box>
        </Modal>
        <div>
          <h1 className='galleryHeading'>Our Happy Travelers</h1>
          <div id="flexbox">
            <div class="column">
              <img src="https://docs.google.com/uc?export=download&id=1U4Z-2GJcRDtIAmZt4ej0MOF_NvA0ntzS" alt="Image" width="100%" />
            </div>
          </div>
        </div>
      </div>
    </div>
  );
};

export default AdminGallery;
