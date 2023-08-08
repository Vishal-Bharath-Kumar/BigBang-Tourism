import React,{useState,useEffect} from 'react'
import './AdminDashboard.css'
import AdminNavbar from '../Admin Navbar/AdminNavbar'
import PersonRemoveOutlinedIcon from '@mui/icons-material/PersonRemoveOutlined';
import { Button } from '@mui/material';
import axios from 'axios';

const AdminDashboard = () => {
    const [isActive, setIsActive] = useState(true);

    const handleButtonClick = () => {
      setIsActive((prevIsActive) => !prevIsActive);
    };
    const [users, setUsers] = useState([]);
    const [loading, setLoading] = useState(true);
    useEffect(() => {
        // Function to fetch users data from the API with userRole filter
        const fetchUsers = async () => {
          try {
            const response = await axios.get('https://localhost:7204/api/User', {
              params: {
                userRole: 1, // Filter users with userRole equal to 1
              },
            });
            setUsers(response.data);
            
            setLoading(false);
          } catch (error) {
            console.error('Error fetching users:', error);
            setLoading(false);
          }
        };
    
        fetchUsers();
      }, []);


      const handleStatusUpdate = async (userId, updatedStatus) => {
        
        try {
          // Make the PUT request to update the user status

          if(updatedStatus==1){

            await axios.put(`https://localhost:7204/api/User/${userId}`, {
                // Include the updated status in the request body
                "userStatus": updatedStatus,
              });
          }
          else{
            await axios.put(`https://localhost:7204/api/User/${userId}`, {
                // Include the updated status in the request body
                "userStatus": updatedStatus,
              });
          }
         
      
          // Update the user status in the UI
          setUsers((prevUsers) =>
            prevUsers.map((user) =>
              user.userId === userId ? { ...user, userStatus: updatedStatus } : user
            )
          );
        } catch (error) {
          console.error('Error updating user status:', error);
        }
      };

      const handleDeleteUser = async (userId) => {
        
        try {
            console.log(userId);
          // Make the DELETE request to remove the user
          await axios.delete(`https://localhost:7204/api/User/${userId}`);
      
          // Remove the user from the UI
          setUsers((prevUsers) => prevUsers.filter((user) => user.userId !== userId));
        } catch (error) {
            
          console.error('Error deleting user:', error);
        }
      };
      

  return (
    <>
    <div className="adminDashboardContainer">
        <AdminNavbar />
        <div className='dashboard'>
            <table className='dashboardTable'>
                <thead className='dashboardHead'>
                <tr className='dashboardRow'>
                    <th className='dashboardTh'>Agent Name</th>
                    <th className='dashboardTh'>Email</th>
                    <th className='dashboardTh'>Status</th>
                    <th className='dashboardTh'>Deny</th>
                    

                </tr>
                </thead>
                <tbody className='dashboardBody'>
                {users.map((user) => (
                // Check the userRole and render the user only if userRole is 1
                user.userRole === 1 && (
                  <tr key={user.userId} className='dashboardRow'>
                    <td className='dashboardValue'>{user.username}</td>
                    <td className='dashboardValue'>{user.emailId}</td>
                    <td className='dashboardValue'>
                      {user.userStatus === 0 ? (
                        <Button variant="contained" color="primary" onClick={() => handleStatusUpdate(user.userId, 1)}>
                          Active
                        </Button>
                      ) : (
                        <Button variant="outlined" color="error" onClick={() => handleStatusUpdate(user.userId, 0)}>
                          Inactive
                        </Button>
                      )}
                    </td>
                    <td className='dashboardValue'><PersonRemoveOutlinedIcon className='DeleteIcon' onClick={() => handleDeleteUser(user.userId)} /></td>
                  </tr>
                )
              ))}
              
                </tbody>
            </table>
        </div>
        </div>
    </>
  )
}

export default AdminDashboard


// import React, { useState, useEffect } from 'react';
// import axios from 'axios';

// const UserList = () => {
//   const [users, setUsers] = useState([]);
//   const [loading, setLoading] = useState(true);

//   useEffect(() => {
//     // Function to fetch users data from the API
//     const fetchUsers = async () => {
//       try {
//         const response = await axios.get('https://localhost:7204/api/User');
//         setUsers(response.data);
//         setLoading(false);
//       } catch (error) {
//         console.error('Error fetching users:', error);
//         setLoading(false);
//       }
//     };

//     fetchUsers();
//   }, []);

//   return (
//     <div>
//       <h1>User List</h1>
//       {loading ? (
//         <p>Loading...</p>
//       ) : (
//         <ul>
//           {users.map((user) => (
//             <li key={user.id}>{user.username}</li>
//           ))}
//         </ul>
//       )}
//     </div>
//   );
// };

// export default UserList;
