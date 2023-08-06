import React, { useState } from 'react';
import AdminNavbar from '../Admin Navbar/AdminNavbar';
import './AdminGallery.css';

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
      <button onClick={handleOpenModal} className="addImageButton">
        Add Image
      </button>

      {/* Modal */}
      {isModalOpen && (
        <div className="modal">
          <div className="modal-content">
            <span className="close-button" onClick={handleCloseModal}>
              &times;
            </span>
            <h2>Choose Image</h2>
            <input type="file" onChange={handleFileInputChange} />
          </div>
        </div>
      )}
    </div>
  );
};

export default AdminGallery;
