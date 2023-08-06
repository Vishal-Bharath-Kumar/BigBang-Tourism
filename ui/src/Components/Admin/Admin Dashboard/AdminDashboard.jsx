import React,{useState} from 'react'
import './AdminDashboard.css'
import AdminNavbar from '../Admin Navbar/AdminNavbar'
import PersonRemoveOutlinedIcon from '@mui/icons-material/PersonRemoveOutlined';
import { Button } from '@mui/material';

const AdminDashboard = () => {
    const [isActive, setIsActive] = useState(true);

    const handleButtonClick = () => {
      setIsActive((prevIsActive) => !prevIsActive);
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
                <tr className='dashboardRow'>
                    <td className='dashboardValue'>Vishal</td>
                    <td className='dashboardValue'>vishalbharathkumar@gmail.com</td>
                    <td className='dashboardValue'>
                    {isActive ? (
                        <Button variant="contained" color="primary" onClick={handleButtonClick}>
                        Active
                        </Button>
                    ) : (
                        <Button variant="outlined" color="error" onClick={handleButtonClick}>
                        Inactive
                        </Button>
                    )}
                    </td>
                    <td className='dashboardValue'><PersonRemoveOutlinedIcon className='DeleteIcon'></PersonRemoveOutlinedIcon></td>
                </tr>
                </tbody>
            </table>
        </div>
        </div>
    </>
  )
}

export default AdminDashboard